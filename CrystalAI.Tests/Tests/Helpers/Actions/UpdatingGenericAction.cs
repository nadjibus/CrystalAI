// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// UpdatingGenericAction.cs is part of Crystal AI.
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

    public class UpdatingGenericAction : ActionBase<CustomContext>
    {
        int _currentIteration;
        public int MaxIterations { get; set; }

        public override IAction Clone()
        {
            return new UpdatingGenericAction(this);
        }

        protected override void OnExecute(CustomContext context)
        {
            _currentIteration = 1;
        }

        protected override void OnUpdate(CustomContext context)
        {
            _currentIteration++;
            if (_currentIteration >= MaxIterations)
                EndInSuccess(context);
        }

        protected override void OnStop(CustomContext context)
        {
        }

        public UpdatingGenericAction()
        {
        }

        UpdatingGenericAction(UpdatingGenericAction other) : base(other)
        {
        }

        public UpdatingGenericAction(int iterations)
        {
            MaxIterations = iterations;
        }
    }

}