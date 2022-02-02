// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IAIPrototype.cs is part of Crystal AI.
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
    /// Interface to all AiPrototypes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAiPrototype<T>
    {
        /// <summary>
        /// Creates a new instance of the implementing class. Note that the semantics here
        /// are somewhat vague, however, by convention the "Prototype Pattern" uses a "Clone"
        /// function. Note that this may have very different semantics when compared with either
        /// shallow or deep cloning. When implementing this remember to include only the defining
        /// characteristics of the class and not its state!
        /// </summary>
        T Clone();
    }

}