// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// DeferredCommandTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using NUnit.Framework;


namespace Crystal.SchedulingTests
{

    [TestFixture]
    internal class DeferredCommandTests
    {
        [Test]
        public void ConstructorTest()
        {
            CommandAction ca = () => { };
            var dc = new DeferredCommand(ca);
            Assert.IsNotNull(dc);
        }

        [Test]
        public void NullProcessThrowsTest()
        {
            Assert.Throws<DeferredCommand.ProcessNullException>(() => new DeferredCommand(null));
        }

        [Test]
        public void RepeatingTest()
        {
            CommandAction ca = () => { };
            var dc = new DeferredCommand(ca);
            Assert.That(dc.IsRepeating, Is.True);
            dc.IsRepeating = false;
            Assert.That(dc.IsRepeating, Is.False);
        }

        [Test]
        public void GetSetFirstExecutionDelayMinTest()
        {
            CommandAction ca = () => { };
            var dc = new DeferredCommand(ca);
            Assert.That(dc.InitExecutionDelayInterval.LowerBound, Is.EqualTo(0f));

            dc.InitExecutionDelayInterval = dc.InitExecutionDelayInterval.ChangeLowerBound(0.5f);
            Assert.That(dc.InitExecutionDelayInterval.LowerBound, Is.EqualTo(0.5f));

            dc.InitExecutionDelayInterval = dc.InitExecutionDelayInterval.ChangeLowerBound(-1f);
            Assert.That(dc.InitExecutionDelayInterval.LowerBound, Is.EqualTo(0f));
        }
    }

}