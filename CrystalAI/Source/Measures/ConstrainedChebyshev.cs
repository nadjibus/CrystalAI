﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ConstrainedChebyshev.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;
using System.Linq;


namespace Crystal
{

    /// <summary>
    /// Calculates the Chebyshev measure <see cref="https://en.wikipedia.org/wiki/Chebyshev_distance"/> for all 
    /// elements whose <see cref="P:Crystal.Utility.Combined"/> is above the set lower bound. 
    /// </summary>
    /// <seealso cref="T:Crystal.IMeasure" />
    public sealed class ConstrainedChebyshev : IMeasure
    {
        float _lowerBound;
        Chebyshev _measure;

        /// <summary>
        ///   If the combined value of any utility is below this, the value of this measure will be 0.
        /// </summary>
        public float LowerBound
        {
            get { return _lowerBound; }
            set { _lowerBound = value.Clamp01(); }
        }

        /// <summary>
        /// Calculate the constrained Chebyshev measure for the given set of elements.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public float Calculate(ICollection<Utility> elements)
        {
            if (elements.Any(el => el.Combined < LowerBound))
                return 0.0f;

            return _measure.Calculate(elements);
        }

        /// <summary>
        /// Creates a new instance of the implementing class. Note that the semantics here
        /// are somewhat vague, however, by convention the "Prototype Pattern" uses a "Clone"
        /// function. Note that this may have very different semantics when compared with either
        /// shallow or deep cloning. When implementing this remember to include only the defining
        /// characteristics of the class and not its state!
        /// </summary>
        /// <returns></returns>
        public IMeasure Clone()
        {
            return new ConstrainedChebyshev(LowerBound);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstrainedChebyshev"/> class.
        /// </summary>
        public ConstrainedChebyshev()
        {
            _measure = new Chebyshev();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstrainedChebyshev"/> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        public ConstrainedChebyshev(float lowerBound)
        {
            LowerBound = lowerBound;
            _measure = new Chebyshev();
        }
    }

}