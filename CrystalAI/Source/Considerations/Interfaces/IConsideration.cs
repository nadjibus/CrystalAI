// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IConsideration.cs is part of Crystal AI.
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
    /// Interface to a consideration.
    /// </summary>
    /// <seealso cref="T:Crystal.IAiPrototype`1" />
    public interface IConsideration : IAiPrototype<IConsideration>
    {
        /// <summary>
        ///   A unique named identifier for this consideration.
        /// </summary>
        string NameId { get; }

        /// <summary>
        ///   Gets or sets the default utility.
        /// </summary>
        Utility DefaultUtility { get; set; }

        /// <summary>
        ///   Returns the utility for this consideration.
        /// </summary>
        Utility Utility { get; }

        /// <summary>
        ///   The weight of this consideration.
        /// </summary>
        float Weight { get; set; }

        /// <summary>
        ///   If true, then the output of the associated evaluator is inverted, in effect, inverting the
        ///   consideration.
        /// </summary>
        bool IsInverted { get; set; }

        /// <summary>Calculates the utility given the specified context.</summary>
        /// <param name="context">The context.</param>
        /// <returns>The utility.</returns>
        void Consider(IContext context);
    }

}