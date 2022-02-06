// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// BehaviourTransitionTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using CrystalAI.TestHelpers;
using NUnit.Framework;


namespace Crystal.ActionTests
{

    [TestFixture]
    public class BehaviourTransitionTests
    {
        AiConstructor _aiConstructor;

        [OneTimeSetUp]
        public void Initialize()
        {
            _aiConstructor = new HelperAiConstructor();
        }

        [Test]
        public void DefaultConstructorTest()
        {
            var t = new BehaviourTransition();
            Assert.IsNotNull(t);
        }

        [Test]
        public void CollectionConstructorTest()
        {
            var t = new BehaviourTransition("transitiontob0", "someBehaviour", _aiConstructor.Behaviours);
            Assert.IsNotNull(t);
        }

        [Test]
        public void TargetBehaviourNullExceptionTest()
        {
            Assert.Throws<BehaviourTransition.BehaviourNullException>(() => new BehaviourTransition(null));
        }

        [Test]
        public void ConstructorThrowsNameIdEmptyOrNullTest()
        {
            _aiConstructor.AIs.ClearAll();
            Assert.Throws<ActionBase.NameIdEmptyOrNullException>(
                                                                 () =>
                                                                   new BehaviourTransition("", "a", _aiConstructor.Behaviours));
            _aiConstructor.AIs.ClearAll();
            Assert.Throws<ActionBase.NameIdEmptyOrNullException>(
                                                                 () =>
                                                                   new BehaviourTransition(null,
                                                                                           "a",
                                                                                           _aiConstructor.Behaviours));
            _aiConstructor.AIs.ClearAll();
            Assert.Throws<ActionBase.NameIdEmptyOrNullException>(
                                                                 () =>
                                                                   new BehaviourTransition("some",
                                                                                           "",
                                                                                           _aiConstructor.Behaviours));
            _aiConstructor.AIs.ClearAll();
            Assert.Throws<ActionBase.NameIdEmptyOrNullException>(
                                                                 () =>
                                                                   new BehaviourTransition("some",
                                                                                           null,
                                                                                           _aiConstructor.Behaviours));
        }

        [Test]
        public void ConstructorThrowsActionCollectionNullTest()
        {
            _aiConstructor.AIs.ClearAll();
            Assert.Throws<ActionBase.ActionCollectionNullException>(() => new BehaviourTransition("la", "lida", null));
        }

        [Test]
        public void TargetAiDoesNotExistExceptionTest()
        {
            _aiConstructor.AIs.ClearAll();
            var t = new BehaviourTransition("transition", "behaviour5", _aiConstructor.Behaviours);
            Assert.Throws<BehaviourTransition.BehaviourDoesNotExistException>(() =>
            {
                var s = t.Behaviour;
            });
            var behaviour5 = new Behaviour("behaviour5", _aiConstructor.Behaviours);
            Assert.DoesNotThrow(() =>
            {
                var s = t.Behaviour;
            });
        }
    }

}