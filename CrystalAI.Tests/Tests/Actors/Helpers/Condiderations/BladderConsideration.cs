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




namespace Crystal.ActorTests
{

    public class BladderConsideration : ConsiderationBase<CharacterContext>
    {
        IEvaluator _ev;

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(_ev.Evaluate(context.Bladder), Weight);
        }

        public override IConsideration Clone()
        {
            return new BladderConsideration(this);
        }

        public BladderConsideration()
        {
            var ptA = new Pointf(0.8f, 0f);
            var ptB = new Pointf(1f, 1f);
            _ev = new PowerEvaluator(ptA, ptB, 3.0f);
        }

        BladderConsideration(BladderConsideration other) : base(other)
        {
            var ptA = new Pointf(0.8f, 0f);
            var ptB = new Pointf(1f, 1f);
            _ev = new PowerEvaluator(ptA, ptB, 3.0f);
        }
    }

}