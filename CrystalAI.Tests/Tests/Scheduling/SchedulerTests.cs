// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// SchedulerTests.cs is part of Crystal AI.
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
    internal class SchedulerTests
    {
        [Test]
        public void ConstructorTest()
        {
            var s = new Scheduler();
            Assert.IsNotNull(s);
            Assert.IsNotNull(s.ThinkStream);
            Assert.IsNotNull(s.UpdateStream);
        }

        [Test]
        public void TickTest()
        {
            var s = new Scheduler();
            s.Tick();
        }
    }

}