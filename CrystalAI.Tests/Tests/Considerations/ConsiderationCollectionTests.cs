// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ConsiderationCollectionTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Runtime.InteropServices;
using NUnit.Framework;


#pragma warning disable


namespace Crystal.ConsiderationTests
{

    [TestFixture]
    public class ConsiderationCollectionTests
    {
        [Test]
        public void ConstructorTest()
        {
            var collection = new ConsiderationCollection();
            Assert.IsNotNull(collection);
        }

        [Test]
        public void AddConsiderationTest()
        {
            var collection = new ConsiderationCollection();
            var consideration = new BasicConsideration();
            consideration.NameId = "some";
            Assert.That(collection.Add(consideration));
            Assert.That(collection.Add(consideration) == false);
        }

        [Test]
        public void CreateConsiderationTest()
        {
            var collection = new ConsiderationCollection();
            var consideration = new BasicConsideration();
            consideration.NameId = "some";
            collection.Add(consideration);
            var newConsideration = collection.Create("some");
            Assert.AreEqual(consideration.NameId, newConsideration.NameId);
        }

        [Test]
        public void ContainsConsiderationTest1()
        {
            var collection = new ConsiderationCollection();
            var consideration = new BasicConsideration("name", collection);
            Assert.That(collection.Contains("name"));
        }

        [Test]
        public void ContainsConsiderationTest2()
        {
            var collection = new ConsiderationCollection();
            var consideration = new BasicConsideration();
            consideration.NameId = "name";
            collection.Add(consideration);
            Assert.That(collection.Contains("name"));
        }

        [Test]
        public void NoDuplicateConsiderationsAllowedTest()
        {
            var collection = new ConsiderationCollection();
            var consideration = new BasicConsideration("name", collection);
            Assert.That(collection.Contains("name"));
            Assert.Throws<ConsiderationBase.ConsiderationAlreadyExistsInCollectionException>(() =>
            {
                var nc = new BasicConsideration("name", collection);
            });
        }

        [Test]
        public void ClearTest()
        {
            var collection = new ConsiderationCollection();
            var consideration = new BasicConsideration("name", collection);
            Assert.That(collection.Contains("name"));
            collection.Clear();
            Assert.That(collection.Contains("name") == false);
        }
    }

}