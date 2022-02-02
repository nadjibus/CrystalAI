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


using System;


namespace Crystal.GeneralTests
{

    public class MockAction : ActionBase<MockContext>
    {
        public string Message { get; set; }
        public int Counter { get; set; }

        public override IAction Clone()
        {
            return new MockAction(this);
        }

        protected override void OnExecute(MockContext context)
        {
            Console.WriteLine(Message + " {0}", Counter);
            Counter++;
            EndInSuccess(context);
        }

        protected override void OnUpdate(MockContext context)
        {
        }

        protected override void OnStop(MockContext context)
        {
        }

        public MockAction()
        {
            Initialize();
        }

        MockAction(MockAction other) : base(other)
        {
            Message = other.Message;
            Counter = other.Counter;
        }

        public MockAction(string nameId, IActionCollection collection) : base(nameId, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            Counter = 0;
        }
    }

}