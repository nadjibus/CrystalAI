﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// PowerEvaluatorTests.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System;
using NUnit.Framework;
//using UE = UnityEngine;


namespace Crystal.EvaluatorTests
{

    [TestFixture]
    public class PowerEvaluatorTests
    {
        const float Tolerance = 1e-5f;
        int _evN = 1000;

        [OneTimeSetUp]
        public void Initialize()
        {
        }

        [Test]
        public void DefaultConstructorTest()
        {
            var ev = new PowerEvaluator();
            Assert.IsNotNull(ev);
        }

        [Test]
        public void TwoParamConstructorTest()
        {
            var ptA = new Pointf(0.0f, 0.0f);
            var ptB = new Pointf(1.0f, 1.0f);
            var ev = new PowerEvaluator(ptA, ptB);
            Assert.IsNotNull(ev);
        }

        [Test]
        public void ThreeParamConstructorTest()
        {
            var ptA = new Pointf(0.0f, 0.0f);
            var ptB = new Pointf(1.0f, 1.0f);
            var ev = new PowerEvaluator(ptA, ptB, 2.0f);
            Assert.IsNotNull(ev);
        }

        static readonly object[] PtAandPtBCases = {
      new object[] {-10f, 0f, 10f, 1f},
      new object[] {-10f, 1f, 10f, 0f},
      new object[] {1f, 0.2f, 100f, 0.8f},
      new object[] {0f, -2f, 1f, 2f}
    };

        [Test, TestCaseSource("PtAandPtBCases")]
        public void PtAandPtBTest(float xA, float yA, float xB, float yB)
        {
            var pt1 = new Pointf(xA, yA.Clamp01());
            var pt2 = new Pointf(xB, yB.Clamp01());
            var ev = new PowerEvaluator(pt1, pt2);
            Assert.AreEqual(pt1, ev.PtA);
            Assert.AreEqual(pt2, ev.PtB);
        }

        static readonly object[] EvaluateCases = {
      new object[] {    0.0f,    0.0f,      1.0f,     1.0f,      2.0f },
      new object[] { -100.0f,    0.0f,    100.0f,     1.0f,      2.0f },
      new object[] { -100.0f,    1.0f,    -20.0f,     0.0f,      3.0f },
      new object[] {   42.0f,    0.5f,       54f,     0.6f,    0.234f },
      new object[] {   42.0f,    0.9f,    100.0f,     0.0f,     30.0f },
      new object[] {    0.0f,    2.0f,      4.0f,     0.2f,     0.33f },
      new object[] {    0.0f,   10.0f,  0.00001f,     0.0f,    0.001f },
      new object[] {    0.0f,    1.0f, 0.000001f, 0.99999f,   0.0001f },
      new object[] {-0.0001f, 0.0001f,   0.0001f,     0.0f,  0.00001f },
      new object[] {    0.0f,   10.0f,  0.00001f,     0.0f,     40.0f },
      new object[] {    0.0f,    1.0f, 0.000001f, 0.99999f,  40.0001f },
      new object[] {-0.0001f, 0.0001f,   0.0001f,     0.0f, 40.00001f },
      new object[] {    0.0f,    0.2f,      0.5f,    0.75f,    100.0f },
      new object[] {    0.0f,   0.75f,      0.5f,     0.2f,    100.0f },
      new object[] {    0.0f,   0.75f,      0.5f,    0.75f, 100000.0f }
    };

        [Test, TestCaseSource("EvaluateCases")]
        public void EvaluateTest(float xA, float yA, float xB, float yB, float power)
        {
            var ptA = new Pointf(xA, yA);
            var ptB = new Pointf(xB, yB);
            var ev = new PowerEvaluator(ptA, ptB, power);

            var yAn = yA.Clamp01();
            var yBn = yB.Clamp01();

            var xqArray = CrMath.LinearSpaced(_evN, xA - 0.001f * xA, xB + 0.001f * xB);
            for (int i = 0; i < _evN - 1; i++)
            {
                var dy = yBn - yAn;
                var dx = xB - xA;
                var cVal = dy * (float)Math.Pow((xqArray[i].Clamp<float>(xA, xB) - xA) / dx, power) + yAn;

                Utility cResult = cVal;
                var aResult = ev.Evaluate(xqArray[i]);
                Assert.That(aResult, Is.EqualTo(cResult.Value).Within(Tolerance));
                Assert.That(aResult <= 1.0f);
                Assert.That(aResult >= 0.0f);
            }
            // Check the end points
            var utilA = ev.Evaluate(xA);
            var utilB = ev.Evaluate(xB);
            Assert.That(utilA, Is.EqualTo(yAn).Within(Tolerance));
            Assert.That(utilB, Is.EqualTo(yBn).Within(Tolerance));
        }



    }

}