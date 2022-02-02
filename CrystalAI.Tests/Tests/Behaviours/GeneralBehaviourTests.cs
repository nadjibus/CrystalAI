// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// GeneralBehaviourTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using Crystal.OptionTests;
using CrystalAI.TestHelpers;
using NUnit.Framework;


namespace Crystal.BehaviourTests
{

    [TestFixture]
    public class GeneralBehaviourTests
    {
        IActionCollection _actions;
        IConsiderationCollection _considerations;
        IOptionCollection _options;
        IBehaviourCollection _behaviours;

        [OneTimeSetUp]
        public void Initialize()
        {
            _actions = new ActionCollection();
            _considerations = new ConsiderationCollection();
            _options = new OptionCollection(_actions, _considerations);
            _behaviours = new BehaviourCollection(_options);
            SetupActions();
            SetupConsiderations();
            SetupOptions();
        }

        [Test]
        public void Nothing()
        {
        }

        void SetupActions()
        {
            _actions.Clear();
            IAction tmpa;
            tmpa = new MockAction("a1", _actions);
            tmpa = new MockAction("a2", _actions);
            tmpa = new MockAction("a3", _actions);
            tmpa = new MockAction("a4", _actions);
        }

        void SetupConsiderations()
        {
            _considerations.Clear();
            IConsideration tmpc;
            tmpc = new OptionConsideration1("c1", _considerations);
            tmpc = new OptionConsideration1("c2", _considerations);
            tmpc = new OptionConsideration1("c3", _considerations);
            tmpc = new OptionConsideration1("c4", _considerations);
            tmpc = new OptionConsideration1("c5", _considerations);
        }

        void SetupOptions()
        {
            _options.Clear();
            IOption tmpo;
            tmpo = new Option("o1", _options);
            tmpo.SetAction("a1");
            tmpo.AddConsideration("c1");
            tmpo.AddConsideration("c2");

            tmpo = new Option("o2", _options);
            tmpo.SetAction("a2");
            tmpo.AddConsideration("c3");
            tmpo.AddConsideration("c4");
        }
    }

}