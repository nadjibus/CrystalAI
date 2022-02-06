﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// DeferredCommand.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System;


namespace Crystal
{

    /// <summary>
    ///   This delegate is used for the process in DeferredCommand
    /// </summary>
    public delegate void CommandAction();

    /// <summary>
    ///   DeferredCommand is a command whose execution is delegated to a future time and/or executes
    ///   repeatedly.
    /// </summary>
    public class DeferredCommand
    {

        // This is by and far the most common use.
        bool _isRepeating = true;
        CommandAction _process;
        private readonly ITimeProvider _timeProvider;
        long _timesExecuted;
        float _lastExecutionTime;
        float _lastUpdateDeltaTime;


        /// <summary>
        ///   Gets or sets a value indicating whether this instance is repeating.
        /// </summary>
        /// <value><c>true</c> if this instance is repeating; otherwise, <c>false</c>.</value>
        public bool IsRepeating
        {
            get { return _isRepeating; }
            set { _isRepeating = value; }
        }

        Interval<float> _initExecutionDelayInterval = Interval.Create(0f);

        /// <summary>
        /// The initial execution delay interval in seconds. If this is a point interval (e.g. [a,a]) the delay
        /// is deterministic, i.e. always equal to the given point.
        /// </summary>
        public Interval<float> InitExecutionDelayInterval
        {
            get { return _initExecutionDelayInterval; }
            set { _initExecutionDelayInterval = value.ClampToPositive(); }
        }

        // The default execution delay is ~16 milliseconds, i.e. the period of a frame in a game running at 60 fps.
        Interval<float> _executionDelayInterval = Interval.Create(0.0167f);
        /// <summary>
        /// The execution delay interval in seconds. If this is a point interval (e.g. [a,a]) the delay
        /// is deterministic, i.e. always equal to the given point.
        /// </summary>
        public Interval<float> ExecutionDelayInterval
        {
            get { return _executionDelayInterval; }
            set { _executionDelayInterval = value.ClampToPositive(); }
        }

        /// <summary>
        ///   This determines how much Time to wait (in seconds), before executing the scheduled item
        ///   for the first Time. This is ignored after the first execution
        /// </summary>
        /// <value>The first execution delay.</value>
        public float InitExecutionDelay
        {
            get { return PcgExtended.Default.NextFloat(_initExecutionDelayInterval); }
        }

        /// <summary>
        ///   The Time to wait in seconds to execute again the scheduled item.
        /// </summary>
        /// <value>The next execution delay.</value>
        public float ExecutionDelay
        {
            get { return PcgExtended.Default.NextFloat(_executionDelayInterval); }
        }

        /// <summary>
        ///   The number of times the Execute() command was called.
        /// </summary>
        public long TimesExecuted
        {
            get { return _timesExecuted; }
        }

        /// <summary>
        ///   The time of the last execution in seconds since the start of the application.
        /// </summary>
        public float LastExecution
        {
            get { return _lastExecutionTime; }
        }

        /// <summary>
        ///   The time since the last update in seconds.
        /// </summary>
        public float TimeSinceLastUpdate
        {
            get { return _timeProvider.TotalSeconds - _lastExecutionTime; }
        }

        /// <summary>
        ///   This returns the time difference in seconds between the last update time and the second to
        ///   last update time.
        /// </summary>
        public float LastUpdateDeltaTime
        {
            get { return _lastUpdateDeltaTime; }
        }

        /// <summary>
        /// Executes this command.
        /// </summary>
        public void Execute()
        {
            _process();
            var lastExecOld = _lastExecutionTime;
            _lastExecutionTime = _timeProvider.TotalSeconds;
            _lastUpdateDeltaTime = _lastExecutionTime - lastExecOld;
            unchecked
            {
                _timesExecuted++;
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.DeferredCommand"/> class.
        /// </summary>
        /// <param name="process">Process.</param>
        public DeferredCommand(CommandAction process, ITimeProvider timeProvider = null)
        {
            if (process == null)
                throw new ProcessNullException();

            _process = process;
            _timeProvider = timeProvider ?? CrTime.Instance;
        }

        internal class ProcessNullException : Exception
        {
        }
    }

}