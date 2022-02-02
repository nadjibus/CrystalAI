// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// IContextProvider.cs is part of Crystal AI.
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
    ///   Interface for context provider responsible for supplying the <see cref="T:Crystal.IContext"/>
    ///   implementing context instances.
    /// </summary>
    public interface IContextProvider
    {
        /// <summary>
        ///   Retrieves the context instance.
        /// </summary>
        IContext Context();
    }

}