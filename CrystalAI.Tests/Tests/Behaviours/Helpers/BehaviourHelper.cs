// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// BehaviourHelper.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


namespace Crystal.BehaviourTests
{

    public class BehaviourContext : IContext
    {
        float _bval;

        public float Bval
        {
            get { return _bval; }
            set { _bval = value.Clamp01(); }
        }

        public ActionState CurrentActionState { get; }

        public BehaviourContext()
        {
            CurrentActionState = new ActionState();
        }
    }

    public class BehaviourConsideration : ConsiderationBase<BehaviourContext>
    {
        IEvaluator _ev;

        public override void Consider(BehaviourContext context)
        {
            Utility = new Utility(_ev.Evaluate(context.Bval), Weight);
        }

        public override IConsideration Clone()
        {
            return new BehaviourConsideration(this);
        }

        public BehaviourConsideration()
        {
            var ptA = new Pointf(0.0f, 0.0f);
            var ptB = new Pointf(1.0f, 1.0f);
            _ev = new LinearEvaluator(ptA, ptB);
        }

        BehaviourConsideration(BehaviourConsideration other) : base(other)
        {
            var ptA = new Pointf(0.0f, 0.0f);
            var ptB = new Pointf(1.0f, 1.0f);
            _ev = new LinearEvaluator(ptA, ptB);
        }
    }

}