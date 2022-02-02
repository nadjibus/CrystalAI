// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// HungerConsideration.cs is part of Crystal AI.
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

    public class HungerConsideration : ConsiderationBase<CharacterContext>
    {
        public static readonly string Name = "HungerConsideration";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(Evaluator.Evaluate(context.Hunger), Weight);
        }

        public override IConsideration Clone()
        {
            return new HungerConsideration(this);
        }

        public HungerConsideration()
        {
            Initialize();
        }

        HungerConsideration(HungerConsideration other) : base(other)
        {
            Initialize();
        }

        public HungerConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            var ptA = new Pointf(70f, 0f);
            var ptB = new Pointf(100f, 1f);
            Evaluator = new SigmoidEvaluator(ptA, ptB, -0.7f);
        }

    }

}