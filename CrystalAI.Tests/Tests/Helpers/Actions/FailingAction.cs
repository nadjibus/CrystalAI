// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// FailingAction.cs is part of Crystal AI.
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

    public class FailingAction : ActionBase
    {
        public override IAction Clone()
        {
            return new FailingAction(this);
        }

        protected override void OnExecute(IContext context)
        {
            EndInFailure(context);
        }

        public FailingAction()
        {
        }

        FailingAction(FailingAction other) : base(other)
        {
        }

        public FailingAction(string nameId, IActionCollection collection) : base(nameId, collection)
        {
        }
    }

}