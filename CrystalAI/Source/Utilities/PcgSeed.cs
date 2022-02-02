// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// PcgSeed.cs is part of Crystal AI.
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
    /// Random number generator seed helper class.
    /// </summary>
    public static class PcgSeed
    {
        /// <summary>
        ///   Provides a Time-dependent seed value, matching the default behavior of System.Random.
        /// </summary>
        public static ulong TimeBasedSeed()
        {
            return (ulong)Environment.TickCount;
        }

        /// <summary>
        ///   Provides a seed based on Time and unique GUIDs.
        /// </summary>
        public static ulong GuidBasedSeed()
        {
            ulong upper = (ulong)(Environment.TickCount ^ Guid.NewGuid().GetHashCode()) << 32;
            ulong lower = (ulong)(Environment.TickCount ^ Guid.NewGuid().GetHashCode());
            return upper | lower;
        }
    }

}