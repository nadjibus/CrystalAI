// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IAction.cs is part of Crystal AI.
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
    /// AI Actions Interface. This is the "bottom-line" in that all decision making eventually 
    /// leads to the execution of a class that implements this interface. 
    /// </summary>
    /// <seealso cref="T:Crystal.IAiPrototype`1" />
    public interface IAction : IAiPrototype<IAction>
    {
        /// <summary>
        ///   A unique identifier for this action.
        /// </summary>
        string NameId { get; }

        /// <summary>
        ///   The required cool-down time, in seconds, needed before this action executes again.
        /// </summary>
        float CooldownTime { get; set; }

        void Execute(IContext context);

        bool InCooldown(IContext context);
    }

}