﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// CircularBuffer.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System;
using System.Collections;
using System.Collections.Generic;


namespace Crystal
{

    /// <summary>
    ///   A circular buffer <see cref="https://en.wikipedia.org/wiki/Circular_buffer"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="T:Crystal.ICircularBuffer`1"/>
    /// <seealso cref="T:System.Collections.Generic.IEnumerable`1"/>
    public class CircularBuffer<T> : ICircularBuffer<T>, IEnumerable<T>
    {
        T[] _buffer;
        int _head;
        int _tail;

        /// <summary>
        ///   Number of elements in the buffer.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; private set; }

        /// <summary>
        ///   The maximum capacity of the buffer.
        /// </summary>
        /// <value>The capacity.</value>
        public int Capacity
        {
            get { return _buffer.Length; }
            set
            {
                if (value < 0)
                    return;

                if (value == _buffer.Length)
                    return;

                var buffer = new T[value];
                var count = 0;
                while (Count > 0 && count < value)
                    buffer[count++] = Dequeue();

                _buffer = buffer;
                Count = count;
                _head = count - 1;
                _tail = 0;
            }
        }

        /// <summary>
        ///   Returns the value at the head of the buffer.
        /// </summary>
        /// <value>The head.</value>
        public T Head
        {
            get { return _buffer[_head]; }
        }

        /// <summary>
        ///   Returns the value at the tail of the buffer.
        /// </summary>
        /// <value>The tail.</value>
        public T Tail
        {
            get { return _buffer[_tail]; }
        }

        /// <summary>
        ///   Enqueue the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        public T Enqueue(T item)
        {
            _head = (_head + 1) % Capacity;
            var overwritten = _buffer[_head];
            _buffer[_head] = item;
            if (Count == Capacity)
                _tail = (_tail + 1) % Capacity;
            else
                ++Count;
            return overwritten;
        }

        /// <summary>
        ///   Dequeue this instance.
        /// </summary>
        public T Dequeue()
        {
            if (Count == 0)
                return default(T);

            var dequeued = _buffer[_tail];
            _buffer[_tail] = default(T);
            _tail = (_tail + 1) % Capacity;
            --Count;
            return dequeued;
        }

        /// <summary>
        ///   Clears the buffer.
        /// </summary>
        public void Clear()
        {
            _head = Capacity - 1;
            _tail = 0;
            Count = 0;
        }

        /// <summary>
        ///   Returns the index of the first item equal to the query (item) if such
        ///   an item exists within the buffer, -1 otherwise.
        /// </summary>
        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Equals(item, this[i]))
                    return i;

            return -1;
        }

        /// <summary>
        ///   Removes the element at the given index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 ||
               index >= Count)
                throw new ArgumentOutOfRangeException("index");

            for (var i = index; i > 0; i--)
                this[i] = this[i - 1];

            Dequeue();
        }

        /// <summary>
        ///   Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0 ||
               Capacity == 0)
                yield break;

            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.CircularBuffer`1"/> class.
        /// </summary>
        public CircularBuffer()
        {
            Initialize(DefaultSize);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.CircularBuffer`1"/> class.
        /// </summary>
        /// <param name="size">Size.</param>
        public CircularBuffer(int size)
        {
            Initialize(size);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void Initialize(int size)
        {
            if (size < 0)
                size = DefaultSize;
            _buffer = new T[size];
            _head = size - 1;
        }

        /// <summary>
        ///   Gets or sets the <see cref="T:Crystal.CircularBuffer`1"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                if (index < 0 ||
                   index >= Count)
                    throw new ArgumentOutOfRangeException(index.ToString());

                return _buffer[(_tail + index) % Capacity];
            }
            set
            {
                if (index < 0 ||
                   index >= Count)
                    throw new ArgumentOutOfRangeException(index.ToString());

                _buffer[(_tail + index) % Capacity] = value;
            }
        }

        const int DefaultSize = 4;
    }

}