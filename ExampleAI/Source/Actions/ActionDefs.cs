﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ActionDefs.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


namespace ExampleAI
{

    public static class ActionDefs
    {
        public static readonly string Drink = DrinkAction.Name;
        public static readonly string Eat = EatAction.Name;
        public static readonly string Shower = ShowerAction.Name;
        public static readonly string Toilet = ToiletAction.Name;
        public static readonly string PhysicalExercise = PhysicalExerciseAction.Name;
        public static readonly string Work = WorkAction.Name;
        public static readonly string Sleep = SleepAction.Name;
        public static readonly string Read = ReadAction.Name;
        public static readonly string Idle = IdleAction.Name;
    }

}