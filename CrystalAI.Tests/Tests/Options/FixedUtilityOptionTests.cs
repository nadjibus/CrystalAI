﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// FixedUtilityOptionTests.cs is part of Crystal AI.
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
    public class FixedUtilityOptionTests
    {
        OptionContext _optionContext;

        [OneTimeSetUp]
        public void Initialize()
        {
            _optionContext = new OptionContext();
        }

        [Test]
        public void ConstructorTest()
        {
            var option = new ConstantUtilityOption();
            Assert.IsNotNull(option);
            Assert.That(option.Weight, Is.EqualTo(1.0f).Within(1e-6f));
        }

        [Test]
        public void ConsiderTest(
          [Range(0.0f, 10.0f, 2.5f)] float xval1,
          [Range(0.0f, 10.0f, 2.5f)] float xval2)
        {
            // NEVER use the derived class to call 
            // Consider otherwise the machinery in the base 
            // class is never called!
            IOption option = new ConstantUtilityOption();
            option.DefaultUtility = xval1;
            (option as Option).SetAction(new MockAction());
            var cd1 = new OptionConsideration1();
            var cd2 = new OptionConsideration2();

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

            option.Consider(_optionContext);
            Assert.That(option.Utility.Value, Is.EqualTo(xval1.Clamp01()).Within(1e-6f));
        }
    }

}