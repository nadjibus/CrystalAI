// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// EatAction.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using Crystal;


namespace ExampleAI
{

    public class EatAction : ActionBase<CharacterContext>
    {
        public static readonly string Name = "Eat";

        public override IAction Clone()
        {
            return new EatAction(this);
        }

        protected override void OnExecute(CharacterContext context)
        {
            context.Character.Report(Name);
            context.Hunger -= 80f;
            context.Bladder += 20f;
            context.Wealth -= 50f;
            EndInSuccess(context);
        }

        protected override void OnUpdate(CharacterContext context)
        {
        }

        public EatAction()
        {
        }

        EatAction(EatAction other) : base(other)
        {
        }

        public EatAction(IActionCollection collection) : base(Name, collection)
        {
        }
    }

}