﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// BladderConsideration.cs is part of Crystal AI.
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

    public class BladderConsideration : ConsiderationBase<CharacterContext>
    {

        public static readonly string Name = "BladderConsideration";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(Evaluator.Evaluate(context.Bladder), Weight);
        }

        public override IConsideration Clone()
        {
            return new BladderConsideration(this);
        }

        public BladderConsideration()
        {
            Initialize();
        }

        BladderConsideration(BladderConsideration other) : base(other)
        {
            Initialize();
        }

        public BladderConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            var ptA = new Pointf(0f, 0f);
            var ptB = new Pointf(100f, 1f);
            Evaluator = new PowerEvaluator(ptA, ptB, 3f);
        }

    }

}