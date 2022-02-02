// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IMeasure.cs is part of Crystal AI.
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
    ///   The measure interface. Note this refers to the mathematical measure
    ///   <see cref="https://en.wikipedia.org/wiki/Measure_(mathematics)"/>
    /// </summary>
    public interface IMeasure : IAiPrototype<IMeasure>
    {
        /// <summary>
        ///   Calculate the measure for the given set of elements.
        /// </summary>
        float Calculate(ICollection<Utility> elements);
    }

}