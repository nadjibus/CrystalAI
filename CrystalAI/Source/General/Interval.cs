﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// Interval.cs is part of Crystal AI.
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
    ///   An interval could be open and closed or combination of both at either
    ///   end.
    /// </summary>
    public enum IntervalType
    {
        /// <summary>
        /// Represents an open bound.
        /// </summary>
        Open,
        /// <summary>
        /// Represents a closed bound.
        /// </summary>
        Closed
    }

    /// <summary>
    ///   Represents an interval of the form [a, b] or (a, b) or any
    ///   combination of exclusive and inclusive end points.
    /// </summary>
    /// <remarks>
    ///   This is a vector-less interval, therefore if the end element is larger
    ///   than the start element, the interval will swap the two ends around
    ///   such that a is always %lt; b.
    /// </remarks>
    public struct Interval<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Lower bound of the interval.
        /// </summary>
        public T LowerBound { get; }

        /// <summary>
        /// Upper bound of the interval.
        /// </summary>
        public T UpperBound { get; }

        /// <summary>
        /// The type of the lower bound of this interval. This can either be 
        /// <see cref="F:Crystal.IntervalType.Open"/> or <see cref="F:Crystal.IntervalType.Closed"/>.
        /// </summary>
        public IntervalType LowerBoundType { get; }
        /// <summary>
        /// The type of the upper bound of this interval. This can either be 
        /// <see cref="F:Crystal.IntervalType.Open"/> or <see cref="F:Crystal.IntervalType.Closed"/>.
        /// </summary>
        public IntervalType UpperBoundType { get; }

        /// <summary>
        ///   Check if given point lies within the interval.
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <returns>True if point lies within the interval, otherwise false</returns>
        public bool Contains(T point)
        {
            var lower = LowerBoundType == IntervalType.Open
                          ? LowerBound.CompareTo(point) < 0
                          : LowerBound.CompareTo(point) <= 0;
            var upper = UpperBoundType == IntervalType.Open
                          ? UpperBound.CompareTo(point) > 0
                          : UpperBound.CompareTo(point) >= 0;

            return lower && upper;
        }

        /// <summary>
        ///   Convert to mathematical notation using open and closed parenthesis:
        ///   (, ), [, and ].
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}{1}, {2}{3}",
                                 LowerBoundType == IntervalType.Open ? "(" : "[",
                                 LowerBound.ToString(),
                                 UpperBound.ToString(),
                                 UpperBoundType == IntervalType.Open ? ")" : "]"
                                );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T}"/> struct.
        /// </summary>
        /// <param name="point">The point.</param>
        public Interval(T point) : this(point, point)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T}"/> struct.
        /// </summary>
        /// <param name="lowerbound">The lower bound.</param>
        /// <param name="upperbound">The upper bound.</param>
        /// <param name="lowerboundIntervalType">Type of the lower bound of the interval.</param>
        /// <param name="upperboundIntervalType">Type of the upper bound of the interval.</param>
        public Interval(T lowerbound, T upperbound,
                        IntervalType lowerboundIntervalType = IntervalType.Closed,
                        IntervalType upperboundIntervalType = IntervalType.Closed)
          : this()
        {
            var a = lowerbound;
            var b = upperbound;
            var comparison = a.CompareTo(b);

            if (comparison > 0)
            {
                a = upperbound;
                b = lowerbound;
            }

            LowerBound = a;
            UpperBound = b;
            LowerBoundType = lowerboundIntervalType;
            UpperBoundType = upperboundIntervalType;
        }
    }

    /// <summary>
    ///   Static class to generate regular Intervals using common types.
    /// </summary>
    public static class Interval
    {

        /// <summary>
        /// Creates the specified point interval.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static Interval<int> Create(int point)
        {
            return new Interval<int>(point);
        }

        /// <summary>
        /// Creates an interval of integers.
        /// </summary>
        /// <param name="lowerbound">The lower bound.</param>
        /// <param name="upperbound">The upper bound.</param>
        /// <param name="lowerboundIntervalType">Type of the lower bound of the interval.</param>
        /// <param name="upperboundIntervalType">Type of the upper bound of the interval.</param>
        /// <returns></returns>
        public static Interval<int> Create(int lowerbound, int upperbound,
                                          IntervalType lowerboundIntervalType = IntervalType.Closed,
                                          IntervalType upperboundIntervalType = IntervalType.Closed)
        {
            return new Interval<int>(lowerbound, upperbound, lowerboundIntervalType, upperboundIntervalType);
        }

        /// <summary>
        /// Creates the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static Interval<float> Create(float point)
        {
            return new Interval<float>(point);
        }

        /// <summary>
        /// Creates an interval of single precision floating point numbers.
        /// </summary>
        /// <param name="lowerbound">The lower bound.</param>
        /// <param name="upperbound">The upper bound.</param>
        /// <param name="lowerboundIntervalType">Type of the lower bound of the interval.</param>
        /// <param name="upperboundIntervalType">Type of the upper bound of the interval.</param>
        /// <returns></returns>
        public static Interval<float> Create(float lowerbound, float upperbound,
                                            IntervalType lowerboundIntervalType = IntervalType.Closed,
                                            IntervalType upperboundIntervalType = IntervalType.Closed)
        {
            return new Interval<float>(lowerbound, upperbound, lowerboundIntervalType, upperboundIntervalType);
        }

        /// <summary>
        /// Creates an interval of double precision floating point numbers.
        /// </summary>
        /// <param name="lowerbound">The lower bound.</param>
        /// <param name="upperbound">The upper bound.</param>
        /// <param name="lowerboundIntervalType">Type of the lower bound of the interval.</param>
        /// <param name="upperboundIntervalType">Type of the upper bound of the interval.</param>
        /// <returns></returns>
        public static Interval<double> Create(double lowerbound, double upperbound,
                                             IntervalType lowerboundIntervalType = IntervalType.Closed,
                                             IntervalType upperboundIntervalType = IntervalType.Closed)
        {
            return new Interval<double>(lowerbound, upperbound, lowerboundIntervalType, upperboundIntervalType);
        }
    }

}