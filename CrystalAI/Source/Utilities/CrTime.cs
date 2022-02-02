// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// CrTime.cs is part of Crystal AI.
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
    /// Clock.
    /// </summary>
    public static class CrTime
    {
        static readonly Stopwatch Clock;

        /// <summary>
        ///   The time in seconds since the start of the game.
        /// </summary>
        public static float TotalSeconds
        {
            get { return (float)Clock.Elapsed.TotalSeconds; }
        }

        /// <summary>
        /// The time in milliseconds since the start of the game.
        /// </summary>
        /// <value>
        /// The milliseconds.
        /// </value>
        public static float TotalMilliseconds
        {
            get { return (float)Clock.Elapsed.TotalMilliseconds; }
        }

        /// <summary>
        /// Initializes the <see cref="CrTime"/> class.
        /// </summary>
        static CrTime()
        {
            Clock = new Stopwatch();
            Clock.Start();
        }
    }

}