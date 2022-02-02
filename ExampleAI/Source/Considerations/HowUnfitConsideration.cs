// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// HowUnfitConsideration.cs is part of Crystal AI.
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

    public class HowUnfitConsideration : ConsiderationBase<CharacterContext>
    {
        public static readonly string Name = "HowUnfit";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(Evaluator.Evaluate(context.Fitness), Weight);
        }

        public override IConsideration Clone()
        {
            return new HowUnfitConsideration(this);
        }

        public HowUnfitConsideration()
        {
            Initialize();
        }

        HowUnfitConsideration(HowUnfitConsideration other) : base(other)
        {
            Initialize();
        }

        public HowUnfitConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            var ptA = new Pointf(0f, 1f);
            var ptB = new Pointf(40f, 0f);
            Evaluator = new PowerEvaluator(ptA, ptB, 4f);
        }

    }

}