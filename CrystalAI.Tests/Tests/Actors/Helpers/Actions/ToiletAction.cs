// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ToiletAction.cs is part of Crystal AI.
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

    public class ToiletAction : ActionBase<CharacterContext>
    {
        protected override void OnExecute(CharacterContext context)
        {
            var bladderBefore = context.Bladder;
            context.Bladder -= 0.8f;
            if (context.Bladder < 0.0f)
                context.Bladder = 0.0f;
            Console.WriteLine("Toilet... Bladder before {0}, after {1}", bladderBefore, context.Bladder);
            EndInSuccess(context);
        }
    }

}