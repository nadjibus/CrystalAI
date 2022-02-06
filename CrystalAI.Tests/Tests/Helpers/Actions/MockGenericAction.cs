// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// MockGenericAction.cs is part of Crystal AI.
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

    public class MockGenericAction : ActionBase<CustomContext>
    {
        protected override void OnExecute(CustomContext context)
        {
            EndInSuccess(context);
        }

        protected override void OnUpdate(CustomContext context)
        {
            EndInSuccess(context);
        }

        protected override void OnStop(CustomContext context)
        {
        }

        public MockGenericAction()
        {
        }

        protected MockGenericAction(MockGenericAction other) : base(other)
        {
        }

        public MockGenericAction(string nameId, IActionCollection collection) : base(nameId, collection)
        {
        }
    }

}