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


using System;


namespace Crystal.ActorTests
{

    public class EatAction : ActionBase<CharacterContext>
    {
        protected override void OnExecute(CharacterContext context)
        {
            var hungerBefore = context.Hunger;
            context.Hunger -= 0.8f;
            if (context.Hunger < 0.0f)
                context.Hunger = 0.0f;
            context.Bladder += 0.2f;
            if (context.Bladder > 1.0f)
                context.Bladder = 1.0f;
            Console.WriteLine("Eating... Hunger before {0}, after {1}", hungerBefore, context.Hunger);
            EndInSuccess(context);
        }
    }

}