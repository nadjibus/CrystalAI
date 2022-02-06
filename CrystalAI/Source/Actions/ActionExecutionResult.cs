// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ActionStatus.cs is part of Crystal AI.
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
    ///   AI Action execution result.
    /// </summary>
    public enum ActionExecutionResult
    {
        /// <summary>
        ///   AI Action failed to execute.
        /// </summary>
        Failure = 0,

        /// <summary>
        ///   The AI Action executed successfully.
        /// </summary>
        Success = 1,

        /// <summary>
        ///   The AI Action is still running.
        /// </summary>
        Running = 2,

        /// <summary>
        ///   The AI is... idle. This is the initial state of all actions. Actions never enter
        ///   this state again after the first execution.
        /// </summary>
        Idle = 3
    }

}