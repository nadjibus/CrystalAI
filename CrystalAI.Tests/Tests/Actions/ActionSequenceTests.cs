// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ActionSequenceTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Threading;
using CrystalAI.TestHelpers;
using NUnit.Framework;


#pragma warning disable


namespace Crystal.ActionTests
{

    [TestFixture]
    public class ActionSequenceTests
    {
        CustomContext _customContext;
        AiConstructor _aiConstructor;

        static object[] _constructorTestCases = {
      new object[] {new ActionSequence()},
      new object[] {new ActionSequence("name", new ActionCollection())}
    };

        static object[] _cloneTestCases = {
      new object[] {new ActionSequence(), 5},
      new object[] {new ActionSequence(), 10},
      new object[] {new ActionSequence("name", new ActionCollection()), 5},
      new object[] {new ActionSequence("name", new ActionCollection()), 10}
    };

        [SetUp]
        public void Initialize()
        {
            _aiConstructor = new HelperAiConstructor();
            _customContext = new CustomContext();
            for (int i = 0; i < 10; i++)
                _customContext.IntList.Add(i);
        }

        [Test, TestCaseSource("_constructorTestCases")]
        public void ConstructionTest(IAction action)
        {
            Assert.IsNotNull(action);
        }

        [Test, TestCase(0.05f), TestCase(0.09f), TestCase(0.1f), Ignore("Work in progress")]
        public void CooldownTest(float cooldown)
        {
            var action = new ActionSequence();
            for (int i = 0; i < 10; i++)
                action.Actions.Add(new MockAction());

            int milliSeconds = (int)(1000 * cooldown) + 1;
            action.CooldownTime = cooldown;
            action.Execute(_customContext);
            Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
            Assert.AreEqual(true, action.InCooldown(_customContext));
            action.Execute(_customContext);
            Assert.AreEqual(ActionExecutionResult.Failure, _customContext.CurrentActionState.ExecutionResult);

            Thread.Sleep(milliSeconds);

            Assert.AreEqual(false, action.InCooldown(_customContext));
            action.Execute(_customContext);
            Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
            Assert.AreEqual(true, action.InCooldown(_customContext));
        }

        [Test]
        public void EnsureActionsExecutedTest()
        {
            var action = new ActionSequence();
            for (int i = 0; i < 10; i++)
                action.Actions.Add(new MockAction());
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(ActionExecutionResult.Idle, _customContext.CurrentActionState.ExecutionResult);

            action.Execute(_customContext);
            Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);

            Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
        }

        [Test, Ignore("Work in progress")]
        public void EnsureUpdatableActionsExecutedTest()
        {
            throw new System.Exception("Test not working ATM...");
            var action = new ActionSequence();
            for (int i = 0; i < 10; i++)
                action.Actions.Add(new UpdatingAction(UpdateIterations));
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(ActionExecutionResult.Idle, _customContext.CurrentActionState.ExecutionResult);

            int count = 0;
            do
            {
                count++;
                action.Execute(_customContext);
            } while (_customContext.CurrentActionState.ExecutionResult == ActionExecutionResult.Running);

            Assert.AreEqual(UpdateIterations, count);
            Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
        }

        [Test, Ignore("Work in progress")]
        public void FailureConditionTest()
        {
            var actionSequence = new ActionSequence();
            for (int i = 0; i < 10; i++)
                actionSequence.Actions.Add(new UpdatingAction(UpdateIterations));
            var newAction = _aiConstructor.Actions.Create(TestActionDefs.FailingAction);
            actionSequence.Actions.Add(newAction);
            for (int i = 0; i < 11; i++)
                Assert.AreEqual(ActionExecutionResult.Idle, _customContext.CurrentActionState.ExecutionResult);

            int count = 0;
            do
            {
                count++;
                actionSequence.Execute(_customContext);
            } while (_customContext.CurrentActionState.ExecutionResult == ActionExecutionResult.Running);

            Assert.AreEqual(UpdateIterations, count);
            Assert.AreEqual(ActionExecutionResult.Failure, _customContext.CurrentActionState.ExecutionResult);
            Assert.AreEqual(ActionExecutionResult.Failure, _customContext.CurrentActionState.ExecutionResult);
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(ActionExecutionResult.Success, _customContext.CurrentActionState.ExecutionResult);
        }

        const int UpdateIterations = 100;
    }

}