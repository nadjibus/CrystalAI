// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// WorkAction.cs is part of Crystal AI.
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

    public class WorkAction : ActionBase<CharacterContext>
    {
        public static readonly string Name = "Work";
        float dWealth = 20f;
        float accumulatedWealth;
        float maxWealthPerSession = 100f;
        public override IAction Clone()
        {
            return new WorkAction(this);
        }

        protected override void OnExecute(CharacterContext context)
        {
            context.Character.Report(Name);
            accumulatedWealth = 0;
            Work(context);
        }

        protected override void OnUpdate(CharacterContext context)
        {
            if (accumulatedWealth >= maxWealthPerSession)
                EndInSuccess(context);

            Work(context);
        }

        public WorkAction()
        {
        }

        WorkAction(WorkAction other) : base(other)
        {
        }

        public WorkAction(IActionCollection collection) : base(Name, collection)
        {
        }

        void Work(CharacterContext context)
        {
            accumulatedWealth += dWealth;
            context.Wealth += dWealth;
            context.Energy -= 2.5f;
            context.Thirst += 2.5f;
            context.Hunger += 4f;
            context.Cleanliness -= 2.5f;
        }

    }

}