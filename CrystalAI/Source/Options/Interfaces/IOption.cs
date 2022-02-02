// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IOption.cs is part of Crystal AI.
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
    ///   Decision related options interface.
    /// </summary>
    public interface IOption : ICompositeConsideration
    {
        /// <summary>
        ///   The action to be executed when this option is selected.
        /// </summary>
        IAction Action { get; }

        /// <summary>
        /// Sets the action to be executed when this option is selected to the action 
        /// associated with actionId. 
        /// </summary>
        /// <param name="actionId">The action identifier.</param>
        /// <returns>Returns true if the action was successfully set, false otherwise.</returns>
        bool SetAction(string actionId);
    }

}