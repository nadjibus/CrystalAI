﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ICircularBuffer.cs is part of Crystal AI.
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
    ///   Circular buffer interface.
    /// </summary>
    public interface ICircularBuffer<T>
    {
        /// <summary>
        ///   Number of elements in the buffer.
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }

        /// <summary>
        ///   The maximum capacity of the buffer.
        /// </summary>
        /// <value>The capacity.</value>
        int Capacity { get; set; }

        /// <summary>
        ///   Returns the value at the head of the buffer.
        /// </summary>
        /// <value>The head.</value>
        T Head { get; }

        /// <summary>
        ///   Returns the value at the tail of the buffer.
        /// </summary>
        /// <value>The tail.</value>
        T Tail { get; }

        /// <summary>
        ///   Enqueue the specified item.
        /// </summary>
        T Enqueue(T item);

        /// <summary>
        ///   Dequeue this instance.
        /// </summary>
        T Dequeue();

        /// <summary>
        ///   Clears the buffer.
        /// </summary>
        void Clear();

        /// <summary>
        ///   Returns the index of the first item equal to the query (item) if such
        ///   an item exists within the buffer, -1 otherwise.
        /// </summary>
        int IndexOf(T item);

        /// <summary>
        ///   Removes the element at the given index.
        /// </summary>
        /// <param name="index">Index.</param>
        void RemoveAt(int index);

        /// <summary>
        ///   Gets or sets the <see cref="T:Crystal.ICircularBuffer`1"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        T this[int index] { get; set; }
    }

}