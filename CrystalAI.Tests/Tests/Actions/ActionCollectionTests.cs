// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ActionCollectionTests.cs is part of Crystal AI.
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


#pragma warning disable


namespace Crystal.ActionTests
{

    [TestFixture]
    public class ActionCollectionTests
    {
        [Test]
        public void ConstructorTest()
        {
            var collection = new ActionCollection();
            Assert.IsNotNull(collection);
        }

        [Test]
        public void AddActionTest()
        {
            var collection = new ActionCollection();
            var action = new MockAction();
            action.NameId = "someaction";
            Assert.That(collection.Add(action));
            Assert.That(collection.Add(action) == false);
        }

        [Test]
        public void CreateActionTest()
        {
            var collection = new ActionCollection();
            var action = new MockAction();
            action.NameId = "someaction";
            collection.Add(action);
            var newAction = collection.Create("someaction");
            Assert.AreEqual(action.NameId, newAction.NameId);
        }

        [Test]
        public void ContainsActionTest1()
        {
            var collection = new ActionCollection();
            var action = new MockAction("name", collection);
            Assert.That(collection.Contains("name"));
        }

        [Test]
        public void ContainsActionTest2()
        {
            var collection = new ActionCollection();
            var action = new MockAction();
            action.NameId = "name";
            collection.Add(action);
            Assert.That(collection.Contains("name"));
        }

        [Test]
        public void ClearTest()
        {
            var collection = new ActionCollection();
            var action = new MockAction("name", collection);
            Assert.That(collection.Contains("name"));
            collection.Clear();
            Assert.That(collection.Contains("name") == false);
        }
    }

}