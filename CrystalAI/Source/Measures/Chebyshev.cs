﻿// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// Chebyshev.cs is part of Crystal AI.
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
    /// Calculates the Chebyshev measure <see cref="https://en.wikipedia.org/wiki/Chebyshev_distance"/>.
    /// </summary>
    /// <seealso cref="T:Crystal.IMeasure" />
    public sealed class Chebyshev : IMeasure
    {

        /// <summary>
        /// Calculate the Chebyshev measure for the given set of elements.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public float Calculate(ICollection<Utility> elements)
        {
            var wsum = 0.0f;
            int count = elements.Count;

            if (count == 0)
                return 0.0f;

            foreach (var el in elements)
                wsum += el.Weight;

            if (CrMath.AeqZero(wsum))
                return 0.0f;

            var vlist = new List<float>(count);
            foreach (var el in elements)
                vlist.Add(el.Value * (el.Weight / wsum));

            var ret = vlist.Max<float>();
            return ret;
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
            return new Chebyshev();
        }
    }

}