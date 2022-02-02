// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// MockAction.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using Crystal;


namespace CrystalAI.TestHelpers
{

    public class MockAction : ActionBase
    {
        public override IAction Clone()
        {
            return new MockAction(this);
        }

        protected override void OnExecute(IContext context)
        {
            EndInSuccess(context);
        }

        public MockAction()
        {
        }

        protected MockAction(MockAction other) : base(other)
        {
        }

        public MockAction(string nameId, IActionCollection collection) : base(nameId, collection)
        {
        }
    }

}