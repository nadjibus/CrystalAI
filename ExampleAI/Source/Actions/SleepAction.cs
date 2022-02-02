﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// SleepAction.cs is part of Crystal AI.
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

    public class SleepAction : ActionBase<CharacterContext>
    {
        public static readonly string Name = "Sleep";

        public override IAction Clone()
        {
            return new SleepAction(this);
        }

        protected override void OnExecute(CharacterContext context)
        {
            context.Character.Report(Name);
            Sleep(context);
        }

        protected override void OnUpdate(CharacterContext context)
        {
            if (context.Energy >= 98f)
                EndInSuccess(context);

            Sleep(context);
        }

        public SleepAction()
        {
        }

        SleepAction(SleepAction other) : base(other)
        {
        }

        public SleepAction(IActionCollection collection) : base(Name, collection)
        {
        }

        void Sleep(CharacterContext context)
        {
            context.Energy += 3.5f;
            context.Bladder += 1f;
            context.Thirst += 0.5f;
            context.Hunger += 0.9f;
        }
    }

}