﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// CommandStream.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Diagnostics;


namespace Crystal
{

    /// <summary>
    ///   The CommandStream processes a given fraction of the AI events on every loop.
    /// </summary>
    public sealed class CommandStream
    {
        float _extraTimeNeeded;
        float _frameBeginTime;

        // A game running at 60fps takes approximately 16ms per update, hence it seems reasonable to have the default AI 
        // update cycle to be one eighth of that as a default.
        double _maxProcessingTime = 2.0;
        float _minimumDelay = 1e-6f;
        QueuedCommand _nextCommand;
        int _processedCommandsCounter;
        Stopwatch _watch;
        private readonly ITimeProvider _timeProvider;

        /// <summary>
        ///   The maximum Time in milliseconds the Process() is allowed to take.
        /// </summary>
        /// <value>The max process Time.</value>
        public double MaxProcessingTime
        {
            get { return _maxProcessingTime; }
            set { _maxProcessingTime = value.ClampToLowerBound(0.1); }
        }

        /// <summary>
        ///   Gets the accumulated number of seconds the updates were overdue this frame, i.e. sum of
        ///   all updates.
        /// </summary>
        public float ExtraTimeNeeded { get; private set; }

        /// <summary>
        ///   Total milliseconds used on the last Process().
        /// </summary>
        public double TotalMilliseconds { get; private set; }

        /// <summary>
        ///   The number of items in the queue that were processed during the previous cycle.
        /// </summary>
        public int ProcessedCount { get; private set; }

        /// <summary>
        ///   The number of scheduled commands in the queue.
        /// </summary>
        public int CommandsCount
        {
            get { return Queue.Count; }
        }

        /// <summary>
        /// Adds the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns></returns>
        public IDeferredCommandHandle Add(DeferredCommand cmd)
        {
            float time = _timeProvider.TotalSeconds;
            var scheduledCommand = new QueuedCommand(this, _timeProvider)
            {
                Command = cmd,
                LastExecution = time,
                NextExecution = time + cmd.InitExecutionDelay
            };

            Queue.Enqueue(scheduledCommand);
            return scheduledCommand;
        }

        /// <summary>
        ///   Processes as many items as possible withing the given Time limits.
        /// </summary>
        public void Process()
        {
            ResetVariables();
            UpdateFrameTimeAndStartClock();

            do
            {
                if (CanGetNextCommand())
                {
                    CalculateOverdueUpdates();
                    ExecuteNextCommand();
                    RescheduleOrRemoveExecutedCommand();
                }
                else
                    break;
            } while (_watch.Elapsed.TotalMilliseconds < MaxProcessingTime);

            UpdatePerformanceMeasurements();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.CommandStream"/> class.
        /// </summary>
        /// <param name="initialQueueSize">Initial queue size.</param>
        public CommandStream(int initialQueueSize, ITimeProvider timeProvider = null)
        {
            _watch = new Stopwatch();
            _timeProvider = timeProvider ?? CrTime.Instance;
            var comparer = new QueuedCommandComparer();
            Queue = new PriorityQueue<QueuedCommand>(initialQueueSize, comparer);
            
        }

        void ResetVariables()
        {
            _nextCommand = null;
            _extraTimeNeeded = 0.0f;
            _processedCommandsCounter = 0;
        }

        /// <summary>
        /// Updates the frame time and start clock.
        /// </summary>
        void UpdateFrameTimeAndStartClock()
        {
            _watch.Reset();
            _watch.Start();
            _frameBeginTime = _timeProvider.TotalSeconds;
        }

        bool CanGetNextCommand()
        {
            if (Queue.HasNext == false)
                return false;

            _nextCommand = Queue.Peek();
            return _nextCommand.NextExecution <= _frameBeginTime;
        }

        void CalculateOverdueUpdates()
        {
            float timeSinceLastUpdate = _frameBeginTime - _nextCommand.LastExecution;
            _extraTimeNeeded += timeSinceLastUpdate - _nextCommand.Command.ExecutionDelay;
        }

        void ExecuteNextCommand()
        {
            _nextCommand.Command.Execute();
            _processedCommandsCounter++;
        }

        void RescheduleOrRemoveExecutedCommand()
        {
            if (_nextCommand.Command.IsRepeating)
                UpdateScheduledItem();
            else
                _nextCommand.IsActive = false;
        }

        void UpdateScheduledItem()
        {
            _nextCommand.LastExecution = _frameBeginTime;
            _nextCommand.NextExecution = _frameBeginTime + _nextCommand.Command.ExecutionDelay + _minimumDelay;
            Queue.Dequeue();
            Queue.Enqueue(_nextCommand);
        }

        void UpdatePerformanceMeasurements()
        {
            ProcessedCount = _processedCommandsCounter;
            ExtraTimeNeeded = _extraTimeNeeded;
            TotalMilliseconds = _watch.Elapsed.TotalMilliseconds;
        }

        internal IPriorityQueue<QueuedCommand> Queue;
    }

}