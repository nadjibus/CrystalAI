// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ArrayExtensions.cs is part of Crystal AI.
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
    ///   Array extensions.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>Gets the index of a value in an @this.</summary>
        /// <typeparam name="T">The type of items in the @this</typeparam>
        /// <param name="this">The @this.</param>
        /// <param name="value">The value to look for.</param>
        /// <returns>The index of the value, or -1 if not found</returns>
        public static int IndexOf<T>(this T[] @this, T value) where T : IEquatable<T>
        {
            for (var i = 0; i < @this.Length; i++)
                if (@this[i].Equals(value))
                    return i;

            return -1;
        }
    }

}