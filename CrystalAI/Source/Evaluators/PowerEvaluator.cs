// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// PowerEvaluator.cs is part of Crystal AI.
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
    ///   The PowerEvaluator returns a normalized utility based on a power function that has
    ///   effectively 1 parameter ( 0 leq p le 10000 ) bounded by the box defined by PtA and PtB with
    ///   PtA.x being strictly less than PtB.x!
    ///   <see href="https://www.desmos.com/calculator/ok9nse8l3u">Power</see> for an interactive
    ///   plot.
    /// </summary>
    public class PowerEvaluator : EvaluatorBase
    {
        float _dy;
        float _p;

        /// <summary>
        ///   Returns the utility for the specified value x.
        /// </summary>
        /// <param name="x">The x value.</param>
        public override float Evaluate(float x)
        {
            var cx = x.Clamp<float>(Xa, Xb);
            cx = _dy * (float)Math.Pow((cx - Xa) / (Xb - Xa), _p) + Ya;
            return cx;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.PowerEvaluator"/> class.
        ///   <see href="https://www.desmos.com/calculator/ok9nse8l3u">Power</see> for an interactive
        ///   plot.
        /// </summary>
        public PowerEvaluator()
        {
            _p = 2.0f;
            Initialize();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.PowerEvaluator"/> class.
        ///   <see href="https://www.desmos.com/calculator/ok9nse8l3u">Power</see> for an interactive
        ///   plot.
        /// </summary>
        /// <param name="ptA">Point a.</param>
        /// <param name="ptB">Point b.</param>
        public PowerEvaluator(Pointf ptA, Pointf ptB) : base(ptA, ptB)
        {
            _p = 2.0f;
            Initialize();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.PowerEvaluator"/> class.
        ///   <see href="https://www.desmos.com/calculator/ok9nse8l3u">Power</see> for an interactive
        ///   plot.
        /// </summary>
        /// <param name="ptA">Point a.</param>
        /// <param name="ptB">Point b.</param>
        /// <param name="power">Power.</param>
        public PowerEvaluator(Pointf ptA, Pointf ptB, float power) : base(ptA, ptB)
        {
            _p = power.Clamp<float>(MinP, MaxP);
            Initialize();
        }

        void Initialize()
        {
            _dy = Yb - Ya;
        }

        const float MinP = 0.0f;
        const float MaxP = 10000f;
    }

}