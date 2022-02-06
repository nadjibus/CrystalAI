// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// UpdatingAction.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using Crystal;


namespace CrystalAI.TestHelpers
{

    public class UpdatingAction : ActionBase
    {
        int _currentIteration;
        public int MaxIterations { get; set; }

        public int UpdatesCount
        {
            get { return _currentIteration; }
        }

        protected override void OnExecute(IContext context)
        {
            _currentIteration = 1;
        }

        protected override void OnUpdate(IContext context)
        {
            _currentIteration++;
            if (_currentIteration >= MaxIterations)
                EndInSuccess(context);
        }

        protected override void OnStop(IContext context)
        {
            // Do nothing
        }

        public UpdatingAction()
        {
        }

        public UpdatingAction(int iterations)
        {
            MaxIterations = iterations;
        }
    }

}