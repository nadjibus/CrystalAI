// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// GeneralOptionTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System;
using CrystalAI.TestHelpers;
using NUnit.Framework;


#pragma warning disable


namespace Crystal.OptionTests
{

    [TestFixture]
    public class GeneralOptionTests
    {
        HelperAiConstructor _aiConstructor;

        [OneTimeSetUp]
        public void Initialize()
        {
            _aiConstructor = new HelperAiConstructor();
            SetupActionsAndConsiderations();
        }

        [Test]
        public void NameConstructorThrowsIfOptionWithNameAlreadyExistsTest()
        {
            _aiConstructor.AIs.ClearAll();
            var o = new Option("name", _aiConstructor.Options);
            Assert.Throws<Option.OptionAlreadyExistsInCollectionException>(() => new Option("name", _aiConstructor.Options));
        }

        [Test]
        public void SetActionIfNullRetrunFalseTest()
        {
            var o = new Option();
            Assert.That(o.SetAction((IAction)null), Is.False);
        }

        [Test]
        public void SetActionStringIfNullOrEmptyFalseTest()
        {
            var o = new Option();
            Assert.That(o.SetAction((string)null), Is.False);
        }

        [Test]
        public void SetActionStringCollectionNullFalseTest()
        {
            var o = new Option();
            Assert.That(o.SetAction("some"), Is.False);
        }

        [Test]
        public void SetActionStringNonExistentFalseTest()
        {
            _aiConstructor.AIs.ClearAll();
            var o = new Option("name", _aiConstructor.Options);
            Assert.That(o.SetAction("nonexistent"), Is.False);
        }

        [Test]
        public void CanAddExistingActionTest()
        {
            _aiConstructor.AIs.ClearAll();
            SetupActionsAndConsiderations();
            var o = new Option("o1", _aiConstructor.Options);
            Assert.That(o.SetAction("a1"));
        }

        [Test]
        public void RefusesToAddNonExistentActionTest()
        {
            _aiConstructor.AIs.ClearAll();
            var o = new Option("o1", _aiConstructor.Options);
            Assert.That(o.SetAction("NonExistentAction"), Is.False);
        }

        [Test]
        public void DoesNotAddEmptyActionTest()
        {
            _aiConstructor.AIs.ClearAll();
            var o = new Option("o1", _aiConstructor.Options);
            Assert.That(o.SetAction(""), Is.False);
        }

        [Test]
        public void DoesNotAddNullStringActionTest()
        {
            _aiConstructor.AIs.ClearAll();
            var o = new Option("o1", _aiConstructor.Options);
            Assert.That(o.SetAction((string)null), Is.False);
        }

        void SetupActionsAndConsiderations()
        {
            _aiConstructor.AIs.ClearAll();

            var tmpa = new MockAction("a1", _aiConstructor.Actions);
            tmpa = new MockAction("a2", _aiConstructor.Actions);
            tmpa = new MockAction("a3", _aiConstructor.Actions);
            tmpa = new MockAction("a4", _aiConstructor.Actions);

            var tmpc = new OptionConsideration1("c1", _aiConstructor.Considerations);
            tmpc = new OptionConsideration1("c2", _aiConstructor.Considerations);
            tmpc = new OptionConsideration1("c3", _aiConstructor.Considerations);
            tmpc = new OptionConsideration1("c4", _aiConstructor.Considerations);
            tmpc = new OptionConsideration1("c5", _aiConstructor.Considerations);
        }
    }

}