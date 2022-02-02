// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// TestEvaluator.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


namespace Crystal.EvaluatorTests
{

    internal class TestEvaluator : EvaluatorBase
    {
        public override float Evaluate(float x)
        {
            return x;
        }

        public TestEvaluator()
        {
        }

        public TestEvaluator(Pointf ptA, Pointf ptB) : base(ptA, ptB)
        {
        }
    }

}