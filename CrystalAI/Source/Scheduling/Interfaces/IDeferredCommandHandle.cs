// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IDeferredCommandHandle.cs is part of Crystal AI.
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
    ///   Interface to represent items added to the load balancer, which allows a number of
    ///   operations to be called.
    /// </summary>
    public interface IDeferredCommandHandle
    {
        /// <summary>
        ///   The scheduled command this handle refers to.
        /// </summary>
        DeferredCommand Command { get; }

        /// <summary>
        ///   If true the associated command is still being executed.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        ///   Pause execution of command.
        /// </summary>
        void Pause();

        /// <summary>
        ///   Resume execution of this command.
        /// </summary>
        void Resume();
    }

}