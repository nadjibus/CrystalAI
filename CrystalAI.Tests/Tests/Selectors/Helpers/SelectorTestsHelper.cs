// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// SelectorTestsHelper.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;


namespace Crystal.SelectorTests
{

    public static class SelectorTestsHelper
    {
        static Pcg _rnd = new Pcg();

        public static List<Utility> CreateRandomUtilityList(int size)
        {
            var list = new List<Utility>();
            for (int i = 0; i < size; i++)
                list.Add(new Utility((float)_rnd.NextDouble(), (float)_rnd.NextDouble()));

            return list;
        }
    }

}