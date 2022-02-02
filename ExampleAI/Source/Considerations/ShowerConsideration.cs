// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ShowerConsideration.cs is part of Crystal AI.
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

    public class ShowerConsideration : ConsiderationBase<CharacterContext>
    {
        public static readonly string Name = "ShowerConsideration";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(Evaluator.Evaluate(context.Cleanliness), Weight);
        }

        public override IConsideration Clone()
        {
            return new ShowerConsideration(this);
        }

        public ShowerConsideration()
        {
            Initialize();
        }

        ShowerConsideration(ShowerConsideration other) : base(other)
        {
            Initialize();
        }

        public ShowerConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            var ptA = new Pointf(0f, 1f);
            var ptB = new Pointf(20f, 0f);
            Evaluator = new SigmoidEvaluator(ptA, ptB, 0.5f);
        }
    }

}