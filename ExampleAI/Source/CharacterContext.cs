﻿// GPL v3 License
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


using Crystal;


namespace ExampleAI
{

    public class CharacterContext : IContext
    {
        float _bladder;
        float _thirst;
        float _hunger;
        float _cleanliness;
        float _energy;
        float _fitness;
        float _wealth;
        float _greedFactor = 0.1f;
        float _greed;

        public float Wealth
        {
            get { return _wealth; }
            set
            {
                var oldWealth = _wealth;
                _wealth = value;
                Greed -= (_wealth - oldWealth) * _greedFactor;
            }
        }

        public float Greed
        {
            get { return _greed; }
            set { _greed = value.Clamp(0f, 100f); }
        }

        public Character Character { get; }

        public float Energy
        {
            get { return _energy; }
            set { _energy = value.Clamp(0f, 100f); }
        }

        public float Fitness
        {
            get { return _fitness; }
            set { _fitness = value.Clamp(0f, 100f); }
        }

        public float Bladder
        {
            get { return _bladder; }
            set { _bladder = value.Clamp(0f, 100f); }
        }

        public float Thirst
        {
            get { return _thirst; }
            set { _thirst = value.Clamp(0f, 100f); }
        }

        public float Hunger
        {
            get { return _hunger; }
            set { _hunger = value.Clamp(0f, 100f); }
        }

        public float Cleanliness
        {
            get { return _cleanliness; }
            set { _cleanliness = value.Clamp(0f, 100f); }
        }

        public ActionState CurrentActionState { get; }

        public override string ToString()
        {
            return string.Format(
                                 "$ {0,6}, Nrg {1,7:00.00%}, Bl {2,7:00.00%}, T {3,7:00.00%}, Hr {4,7:00.00%}, Cl {5,7:00.00%}, Ft {6,7:00.00%}",
                                 Wealth,
                                 Energy / 100f,
                                 Bladder / 100f,
                                 Thirst / 100f,
                                 Hunger / 100f,
                                 Cleanliness / 100f,
                                 Fitness / 100f);
        }

        public CharacterContext(Character character)
        {
            Character = character;
            _bladder = 0f;
            _thirst = 0f;
            _hunger = 0f;
            _fitness = 100f;
            _cleanliness = 100f;
            _energy = 100f;
            _greed = 20f;
            Wealth = 1000f;
            CurrentActionState = new ActionState();
        }
    }

}