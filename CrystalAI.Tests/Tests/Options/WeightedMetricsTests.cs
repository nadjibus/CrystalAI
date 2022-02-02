﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// WeightedMetricsTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;
using CrystalAI.TestHelpers;
using NUnit.Framework;


namespace Crystal.OptionTests
{

    [TestFixture]
    public class WeightedMetricsTests
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
            var o = OptionConstructor.WeightedMetrics();
            Assert.IsNotNull(o);
            Assert.That(o.Weight, Is.EqualTo(1.0f).Within(Tolerance));
        }

        [Test]
        public void ConstructorTest2()
        {
            var option = OptionConstructor.WeightedMetrics(4.0f);
            Assert.IsNotNull(option);
            Assert.AreEqual(4.0f, (option.Measure as WeightedMetrics).PNorm);
        }

        [Test]
        public void ConsiderTest(
          [Range(0.0f, 10.0f, 2.5f)] float xval1,
          [Range(0.0f, 10.0f, 2.5f)] float xval2)
        {
            // NEVER use the derived class to call 
            // Consider otherwise the machinery in the base 
            // class is never called!
            IOption option = new Option();
            (option as Option).SetAction(new MockAction());
            var cd1 = new OptionConsideration1();
            cd1.NameId = "cd1";
            var cd2 = new OptionConsideration2();
            cd2.NameId = "cd2";
            option.AddConsideration(cd1);
            option.AddConsideration(cd2);
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
            option.Consider(_optionContext);
            Assert.That(option.Utility.Value, Is.EqualTo(cNorm).Within(Tolerance));
        }

        const float Tolerance = 1e-6f;
    }

}