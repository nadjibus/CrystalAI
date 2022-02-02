﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// EnergyConsideration.cs is part of Crystal AI.
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

    public class EnergyConsideration : ConsiderationBase<CharacterContext>
    {
        public static readonly string Name = "Energy";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(Evaluator.Evaluate(context.Energy), Weight);
        }

        public override IConsideration Clone()
        {
            return new EnergyConsideration(this);
        }

        public EnergyConsideration()
        {
            Initialize();
        }

        EnergyConsideration(EnergyConsideration other) : base(other)
        {
            Initialize();
        }

        public EnergyConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
            Initialize();
        }

        void Initialize()
        {
            var ptA1 = new Pointf(0f, 0f);
            var ptB1 = new Pointf(20f, 0.2f);
            var powEv = new PowerEvaluator(ptA1, ptB1, 2f);
            var ptA2 = new Pointf(20f, 0.2f);
            var ptB2 = new Pointf(100f, 1f);
            var linEv = new LinearEvaluator(ptA2, ptB2);
            var cmpEv = new CompositeEvaluator();
            cmpEv.Add(powEv);
            cmpEv.Add(linEv);
            Evaluator = cmpEv;
        }

    }

}