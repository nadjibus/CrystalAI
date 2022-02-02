// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ShowerAction.cs is part of Crystal AI.
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

    public class ShowerAction : ActionBase<CharacterContext>
    {
        public static readonly string Name = "Shower";

        public override IAction Clone()
        {
            return new ShowerAction(this);
        }

        protected override void OnExecute(CharacterContext context)
        {
            context.Character.Report(Name);
            context.Cleanliness += 90f;
            context.Energy += 2.5f;
            EndInSuccess(context);
        }

        protected override void OnUpdate(CharacterContext context)
        {
        }

        public ShowerAction()
        {
        }

        ShowerAction(ShowerAction other) : base(other)
        {
        }

        public ShowerAction(IActionCollection collection) : base(Name, collection)
        {
        }
    }

}