// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ConsiderationDefs.cs is part of Crystal AI.
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

    public static class ConsiderationDefs
    {
        public static readonly string Bladder = BladderConsideration.Name;
        public static readonly string Shower = ShowerConsideration.Name;
        public static readonly string Hunger = HungerConsideration.Name;
        public static readonly string Thirst = ThirstConsideration.Name;
        public static readonly string Energy = EnergyConsideration.Name;
        public static readonly string Tiredness = TirednessConsideration.Name;
        public static readonly string HowUnfit = HowUnfitConsideration.Name;

        public static readonly string Greed = GreedConsideration.Name;
        public static readonly string Curiosity = CuriosityConsideration.Name;

        public static readonly string LiveLong = "LiveLong";
        public static readonly string Prosper = "Prosper";
    }

}