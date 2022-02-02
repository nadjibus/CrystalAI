// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IConsiderationCollection.cs is part of Crystal AI.
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
    ///   Interface for a collection that contains <see cref="T:Crystal.IConsideration"/>s
    ///   and <see cref="T:Crystal.ICompositeConsideration"/>s.
    /// </summary>
    public interface IConsiderationCollection
    {
        /// <summary>
        ///   Adds the specified consideration.
        /// </summary>
        /// <param name="consideration">The consideration.</param>
        /// <returns>
        ///   <c>true</c> if the consideration was successfully added to the collection, <c>false</c> otherwise.
        /// </returns>
        bool Add(IConsideration consideration);

        /// <summary>
        /// Determines whether this collection contains a consideration associated with the given identifier.
        /// </summary>
        /// <param name="considerationId">The consideration identifier.</param>
        /// <returns>
        ///   <c>true</c> if the collection contains a consideration with the given identifier; otherwise <c>false</c>.
        /// </returns>
        bool Contains(string considerationId);

        /// <summary>
        ///   Removes all considerations from this collection.
        /// </summary>
        void Clear();

        /// <summary>
        ///   Creates a consideration that has the specified identifier, if no such consideration
        ///   exists within this collection <c>null</c> is returned.
        /// </summary>
        /// <param name="considerationId">The consideration identifier.</param>
        IConsideration Create(string considerationId);
    }

}