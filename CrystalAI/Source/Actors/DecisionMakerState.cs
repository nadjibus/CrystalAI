// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// DecisionMakerState.cs is part of Crystal AI.
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
    ///   Represents the state of a <see cref="T:Crystal.DecisionMakerBase"/>
    /// </summary>
    public enum DecisionMakerState
    {
        /// <summary>
        ///   The associated AI is not running.
        /// </summary>
        Stopped,

        /// <summary>
        ///   The associated AI is running.
        /// </summary>
        Running,

        /// <summary>
        ///   The associated AI is paused.
        /// </summary>
        Paused
    }

}