// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// CustomContext.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;
using Crystal;


namespace CrystalAI.TestHelpers
{

    public class CustomContext : IContext
    {
        public CustomContext()
        {
            CurrentActionState = new ActionState();
        }

        public string Name;
        public string Description;
        public List<int> IntList = new List<int>();

        public Utility BaseUtility;

        public ActionState CurrentActionState { get; }
    }

}