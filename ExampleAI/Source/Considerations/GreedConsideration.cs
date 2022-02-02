﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// GreedConsideration.cs is part of Crystal AI.
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

    public class GreedConsideration : ConsiderationBase<CharacterContext>
    {
        public static readonly string Name = "Greed";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(Evaluator.Evaluate(context.Greed), Weight);
        }

        public override IConsideration Clone()
        {
            return new GreedConsideration(this);
        }

        public GreedConsideration()
        {
            Initialize();
        }

        GreedConsideration(GreedConsideration other) : base(other)
        {
            Initialize();
        }

        public GreedConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            var xa = Pcg.Default.NextFloat(20f, 30f);
            var ptA = new Pointf(xa, 0f);
            var xb = Pcg.Default.NextFloat(40f, 100f);
            var ptB = new Pointf(xb, 1f);
            Evaluator = new SigmoidEvaluator(ptA, ptB, 0.3f);
        }

    }

}