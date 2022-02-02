// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ICompositeConsideration.cs is part of Crystal AI.
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
    ///   Interface for considerations that themselves calculate a Utility based on the Utility of
    ///   <see cref="T:Crystal.IConsideration"/>s. <see cref="T:Crystal.IOption"/> and
    ///   <see cref="T:Crystal.IBehaviour"/> derive from this interface.
    /// </summary>
    public interface ICompositeConsideration : IConsideration
    {
        /// <summary>
        ///   The measure to be used to evaluate the utility of this consideration.
        /// </summary>
        IMeasure Measure { get; set; }

        /// <summary>
        ///   Add the specified consideration.
        /// </summary>
        bool AddConsideration(IConsideration consideration);

        /// <summary>
        ///   Add the consideration associated with the given Id.
        /// </summary>
        bool AddConsideration(string considerationId);
    }

}