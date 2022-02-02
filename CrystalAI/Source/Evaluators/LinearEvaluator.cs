// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// LinearEvaluator.cs is part of Crystal AI.
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
    ///   The LinearEvaluator returns a normalized utility value based on a linear function.
    ///   <see href="https://www.desmos.com/calculator/esibujxim4">Power</see> for an interactive
    ///   plot.
    /// </summary>
    public class LinearEvaluator : EvaluatorBase
    {
        float _dyOverDx;

        /// <summary>
        ///   Returns the value for the specified x.
        /// </summary>
        public override float Evaluate(float x)
        {
            return (Ya + _dyOverDx * (x - Xa)).Clamp01();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.LinearEvaluator"/> class.
        ///   <see href="https://www.desmos.com/calculator/esibujxim4">Power</see> for an interactive
        ///   plot.
        /// </summary>
        public LinearEvaluator()
        {
            Initialize();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.LinearEvaluator"/> class.
        ///   <see href="https://www.desmos.com/calculator/esibujxim4">Power</see> for an interactive
        ///   plot.
        /// </summary>
        /// <param name="ptA">Point a.</param>
        /// <param name="ptB">Point b.</param>
        public LinearEvaluator(Pointf ptA, Pointf ptB) : base(ptA, ptB)
        {
            Initialize();
        }

        void Initialize()
        {
            _dyOverDx = (Yb - Ya) / (Xb - Xa);
        }
    }

}