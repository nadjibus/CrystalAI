﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// WeightedMetricsConsiderationTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;
using Crystal.OptionTests;
using NUnit.Framework;


namespace Crystal.ConsiderationTests
{

    [TestFixture]
    public class WeightedMetricsConsiderationTests
    {
        OptionContext _optionContext;

        [OneTimeSetUp]
        public void Initialize()
        {
            _optionContext = new OptionContext();
        }

        [Test]
        public void ConstructorTest1()
        {
            var c = ConsiderationConstructor.WeightedMetrics();

            Assert.IsNotNull(c);
            Assert.That(c.Weight, Is.EqualTo(1.0f).Within(Tolerance));
        }

        [Test]
        public void ConstructorTest2()
        {
            var c = ConsiderationConstructor.WeightedMetrics(4.0f);

            Assert.IsNotNull(c);
            Assert.AreEqual(4.0f, (c.Measure as WeightedMetrics).PNorm);
        }

        [Test]
        public void ConsiderTest(
          [Range(0.0f, 10.0f, 2.5f)] float xval1,
          [Range(0.0f, 10.0f, 2.5f)] float xval2)
        {
            // NEVER use the derived class to call 
            // Consider otherwise the machinery in the base 
            // class is never called!
            var consideration = ConsiderationConstructor.WeightedMetrics();

            var cd1 = new OptionConsideration1();
            var cd2 = new OptionConsideration2();
            cd1.NameId = "cd1";
            cd2.NameId = "cd2";
            consideration.AddConsideration(cd1);
            consideration.AddConsideration(cd2);
            _optionContext.XVal1 = xval1;
            _optionContext.XVal2 = xval2;
            cd1.Consider(_optionContext);
            cd2.Consider(_optionContext);
            var cUtil1 = cd1.Utility;
            var cUtil2 = cd2.Utility;
            var cUtilL = new List<Utility>();
            cUtilL.Add(cUtil1);
            cUtilL.Add(cUtil2);
            var cNorm = cUtilL.WeightedMetrics();
            consideration.Consider(_optionContext);
            Assert.That(consideration.Utility.Value, Is.EqualTo(cNorm).Within(Tolerance));
        }

        const float Tolerance = 1e-6f;
    }

}