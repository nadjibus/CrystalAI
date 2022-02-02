// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ITransition.cs is part of Crystal AI.
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
    /// Interface to Transitions. A transition is an <see cref="T:Crystal.IAction"/> that transfers control
    /// to a behaviour or another AI.
    /// </summary>
    /// <seealso cref="T:Crystal.IAction" />
    public interface ITransition : IAction
    {

        /// <summary>
        /// Triggers the action selection mechanism of the associated <see cref="T:Crystal.IBehaviour"/> or 
        /// <see cref="T:Crystal.IUtilityAi"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        IAction Select(IContext context);
    }

}