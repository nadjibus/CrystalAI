// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// AIConstructorTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using NUnit.Framework;


namespace Crystal.GeneralTests
{

    [TestFixture]
    public class AiConstructorTests
    {
        IActionCollection _actions;
        IConsiderationCollection _considerations;
        IOptionCollection _options;
        IBehaviourCollection _behaviours;
        IAiCollection _aIs;

        MasterAiConstructor _ctor;


        [OneTimeSetUp]
        public void Initialize()
        {
            _actions = new ActionCollection();
            _considerations = new ConsiderationCollection();
            _options = new OptionCollection(_actions, _considerations);
            _behaviours = new BehaviourCollection(_options);
            _aIs = new AiCollection(_behaviours);
            _ctor = new MasterAiConstructor(_aIs);
        }

        [Test]
        public void ConstructorTest()
        {
            var ai = _ctor.Create(_ctor.CharacterAi);
        }

    }

}