// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// GenericActionBaseTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using Crystal.GeneralTests;
using CrystalAI.TestHelpers;
using NUnit.Framework;


namespace Crystal.ActionTests
{

    [TestFixture]
    internal class GenericActionBaseTests
    {
        MockContext _context;
        HelperAiConstructor _aiConstructor;

        [SetUp]
        public void Initialize()
        {
            _context = new MockContext();
            _aiConstructor = new HelperAiConstructor();
        }

        [Test]
        public void DefaultConstructorTest()
        {
            var a = new ActionBase<MockContext>();
            Assert.IsNotNull(a);
            Assert.AreEqual(ActionExecutionResult.Idle, _context.CurrentActionState.ExecutionResult);
        }

        [Test]
        public void NameConstructorTest()
        {
            _aiConstructor.AIs.ClearAll();
            var a = new ActionBase<MockContext>("name", _aiConstructor.Actions);
            Assert.IsNotNull(a);
            Assert.That(_aiConstructor.Actions.Contains("name"));
        }

        [Test]
        public void NameOrCollectionNullThrowsTest()
        {
            _aiConstructor.AIs.ClearAll();

            Assert.Throws<ActionBase<MockContext>.NameIdEmptyOrNullException>
              (() => new ActionBase<MockContext>(null, _aiConstructor.Actions));

            Assert.Throws<ActionBase<MockContext>.ActionCollectionNullException>
              (() => new ActionBase<MockContext>("name", null));

            Assert.Throws<ActionBase<MockContext>.NameIdEmptyOrNullException>
              (() => new ActionBase<MockContext>(null, null));
        }

        [Test]
        public void ExecuteTest()
        {
            var a = new ActionBase<MockContext>();
            Assert.That(_context.CurrentActionState.ExecutionResult == ActionExecutionResult.Idle);
            Assert.DoesNotThrow(() => a.Execute(_context));
            Assert.That(_context.CurrentActionState.ExecutionResult == ActionExecutionResult.Success);
        }

        [Test]
        public void ExecuteAsIActionTest()
        {
            var a = new ActionBase<MockContext>() as IAction;
            Assert.That(_context.CurrentActionState.ExecutionResult == ActionExecutionResult.Idle);
            Assert.DoesNotThrow(() => a.Execute(_context));
            Assert.That(_context.CurrentActionState.ExecutionResult == ActionExecutionResult.Success);
        }

        [Test]
        public void CooldownTest()
        {
            var a = new ActionBase<MockContext>();
            a.CooldownTime = 20f;
            Assert.That(a.InCooldown(_context), Is.False);
            a.Execute(_context);
            Assert.That(_context.CurrentActionState.ExecutionResult == ActionExecutionResult.Success);
            Assert.That(a.InCooldown(_context), Is.True);
            a.Execute(_context);
            Assert.That(_context.CurrentActionState.ExecutionResult == ActionExecutionResult.Failure);
        }
    }

}