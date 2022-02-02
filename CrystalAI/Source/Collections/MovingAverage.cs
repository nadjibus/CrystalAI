﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// MovingAverage.cs is part of Crystal AI.
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
    /// Uses a circular buffer to adaptively calculate the moving average of the contained 
    /// elements.
    /// </summary>
    public class MovingAverage
    {
        CircularBuffer<float> _buffer;
        bool _latch = true;
        float _mean;

        float _oneOverN = 1.0f;

        /// <summary>
        /// The average. 
        /// </summary>    
        public float Mean
        {
            get { return _mean; }
        }

        /// <summary>
        ///   The
        /// </summary>
        /// <value>The moving average rank.</value>
        public int MovingAverageDepth
        {
            get { return _buffer.Capacity; }
        }

        /// <summary>
        ///   Enqueue the specified value and updates the mean.
        /// </summary>
        public void Enqueue(float val)
        {
            _buffer.Enqueue(val);
            UpdateTheMean();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.MovingAverage"/> class.
        /// </summary>
        public MovingAverage()
        {
            Initialize(DefaultSize);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.MovingAverage"/> class.
        /// </summary>
        /// <param name="length">Length.</param>
        public MovingAverage(int length)
        {
            Initialize(length);
        }

        void Initialize(int size)
        {
            if (size < 2)
            {
                _buffer = new CircularBuffer<float>(DefaultSize);
                _oneOverN = 1.0f / DefaultSize;
            }
            else
            {
                _buffer = new CircularBuffer<float>(size);
                _oneOverN = 1.0f / size;
            }
        }

        float UpdateTheMean()
        {
            if (_latch)
            {
                _mean = _buffer.Mean();
                if (_buffer.Count == _buffer.Capacity)
                    _latch = false;
                return _mean;
            }

            _mean += _oneOverN * (_buffer.Head - _buffer.Tail);
            return _mean;
        }

        const int DefaultSize = 4;
    }

}