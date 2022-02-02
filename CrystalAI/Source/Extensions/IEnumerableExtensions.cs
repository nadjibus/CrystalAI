// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IEnumerableExtensions.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;


namespace Crystal
{

    /// <summary>
    ///   IEnumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the mean value. 
        /// </summary>
        public static float Mean(this IEnumerable<float> @this)
        {
            var sum = 0.0f;
            var count = 0;
            using (var enumerator = @this.GetEnumerator())
                while (enumerator.MoveNext())
                {
                    sum += enumerator.Current;
                    count++;
                }

            return sum / count;
        }
    }

}