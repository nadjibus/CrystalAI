// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// CharacterContext.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 




namespace Crystal.ActorTests
{

    public class CharacterContext : IContext
    {
        float _hunger;
        float _thirst;
        float _bladder;

        public float Hunger
        {
            get { return _hunger; }
            set { _hunger = value.Clamp01(); }
        }

        public float Thirst
        {
            get { return _thirst; }
            set { _thirst = value.Clamp01(); }
        }

        public float Bladder
        {
            get { return _bladder; }
            set { _bladder = value.Clamp01(); }
        }
    }

}