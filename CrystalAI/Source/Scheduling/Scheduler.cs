// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// Scheduler.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


namespace Crystal
{

    /// <summary>
    ///   The AI Scheduler class distributes the execution of the think and update methods
    ///   of the contained AIs in time to avoid excessive lag spikes.
    /// </summary>
    public sealed class Scheduler : IScheduler
    {
        /// <summary>
        ///   The Think cycle.
        /// </summary>
        public CommandStream ThinkStream { get; private set; }

        /// <summary>
        ///   The Update cycle.
        /// </summary>
        /// <value>The update queue.</value>
        public CommandStream UpdateStream { get; private set; }

        /// <summary>
        ///   Tick this instance.
        /// </summary>
        public void Tick()
        {
            ThinkStream.Process();
            UpdateStream.Process();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.Scheduler"/> class.
        /// </summary>
        public Scheduler()
        {
            ThinkStream = new CommandStream(128)
            {
                MaxProcessingTime = 1
            };
            UpdateStream = new CommandStream(128)
            {
                MaxProcessingTime = 3
            };
        }
    }

}