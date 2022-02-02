﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// AbsoluteChebyshevOptionTests.cs is part of Crystal AI.
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
    public class AbsoluteChebyshevOptionTests
    {
        OptionContext _optionContext;

        [OneTimeSetUp]
        public void Initialize()
        {
            _optionContext = new OptionContext();
        }

        [Test]
        public void ConstuctorTest1()
        {
            var option = new Option();
            option.Measure = new ConstrainedChebyshev();
            Assert.IsNotNull(option);
            Assert.That(option.Weight, Is.EqualTo(1.0f).Within(1e-6f));
        }

        [Test]
        public void ConstuctorTest2([Range(-1.0f, 2.0f, 0.1f)] float threshold)
        {
            var option = new Option();
            var measure = new ConstrainedChebyshev();
            measure.LowerBound = threshold;
            option.Measure = measure;

            Assert.IsNotNull(option);
            Assert.That(option.Weight, Is.EqualTo(1.0f).Within(1e-6f));
            Assert.That(measure.LowerBound, Is.EqualTo(threshold.Clamp01()).Within(1e-6f));
        }

        [Test]
        public void ConsiderTest1(
          [Range(0.0f, 10.0f, 2.5f)] float xval1,
          [Range(0.0f, 10.0f, 2.5f)] float xval2)
        {
            // NEVER use the derived class to call 
            // Consider otherwise the machinery in the base 
            // class is never called!
            var option = new Option() as IOption;
            var measure = new ConstrainedChebyshev();
            option.Measure = measure;
            measure.LowerBound = 0.0f;

            (option as Option).SetAction(new MockAction());
            var cd1 = new OptionConsideration1();
            var cd2 = new OptionConsideration2();
            cd1.NameId = "cd1";
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
            var cNorm = cUtilL.Chebyshev();
            option.Consider(_optionContext);
            Assert.That(option.Utility.Value, Is.EqualTo(cNorm).Within(1e-6f));
        }

        [Test]
        public void ConsiderTest2(
          [Range(0.0f, 10.0f, 2.5f)] float xval1,
          [Range(0.0f, 10.0f, 2.5f)] float xval2,
          [Values(0.1f, 0.5f, 0.8f)] float threshold)
        {
            // NEVER use the derived class to call 
            // Consider otherwise the machinery in the base 
            // class is never called!
            var option = new Option() as IOption;
            var measure = new ConstrainedChebyshev();
            option.Measure = measure;
            measure.LowerBound = threshold;

            (option as Option).SetAction(new MockAction());
            var cd1 = new OptionConsideration1();
            var cd2 = new OptionConsideration2();
            cd1.NameId = "cd1";
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
            var cNorm = cUtilL.Chebyshev();
            if (cUtil1.Combined < threshold ||
               cUtil2 < threshold)
                cNorm = 0.0f;
            option.Consider(_optionContext);
            Assert.That(option.Utility.Value, Is.EqualTo(cNorm).Within(1e-6f));
        }
    }

}