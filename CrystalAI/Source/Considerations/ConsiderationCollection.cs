// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ConsiderationCollection.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;


namespace Crystal
{

    /// <summary>
    /// A collection of <see cref="T:Crystal.IConsideration"/>s and 
    /// <see cref="T:Crystal.ICompositeConsideration"/>s
    /// </summary>
    /// <seealso cref="T:Crystal.IConsiderationCollection" />
    public class ConsiderationCollection : IConsiderationCollection
    {
        Dictionary<string, IConsideration> _considerationsMap;

        /// <summary>
        /// Adds the specified consideration.
        /// </summary>
        /// <param name="consideration">The consideration.</param>
        /// <returns>
        ///   <c>true</c> if the consideration was successfully added to the collection, <c>false</c> otherwise.
        /// </returns>
        public bool Add(IConsideration consideration)
        {
            if (consideration == null)
                return false;
            if (_considerationsMap.ContainsKey(consideration.NameId))
                return false;
            if (string.IsNullOrEmpty(consideration.NameId))
                return false;

            _considerationsMap.Add(consideration.NameId, consideration);
            return true;
        }

        /// <summary>
        /// Determines whether this collection contains a consideration associated with the given identifier.
        /// </summary>
        /// <param name="considerationId">The consideration identifier.</param>
        /// <returns>
        ///   <c>true</c> if the collection contains a consideration with the given identifier; otherwise <c>false</c>.
        /// </returns>
        public bool Contains(string considerationId)
        {
            return _considerationsMap.ContainsKey(considerationId);
        }

        /// <summary>
        /// Removes all considerations from this collection.
        /// </summary>
        public void Clear()
        {
            _considerationsMap.Clear();
        }

        /// <summary>
        /// Creates a consideration that has the specified identifier, if no such consideration
        /// exists within this collection <c>null</c> is returned.
        /// </summary>
        /// <param name="considerationId">The consideration identifier.</param>
        /// <returns></returns>
        public IConsideration Create(string considerationId)
        {
            return _considerationsMap.ContainsKey(considerationId) ? _considerationsMap[considerationId].Clone() : null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsiderationCollection"/> class.
        /// </summary>
        public ConsiderationCollection()
        {
            _considerationsMap = new Dictionary<string, IConsideration>();
        }
    }

}