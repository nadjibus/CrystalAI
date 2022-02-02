// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// Toon.cs is part of Crystal AI.
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

    public class Toon : IContextProvider
    {
        CharacterContext _context;

        public IContext Context()
        {
            return _context;
        }

        public void Update()
        {
            _context.Hunger += 0.01f;
            _context.Thirst += 0.005f;
        }

        public Toon()
        {
            _context = new CharacterContext();
            _context.Hunger = 0.0f;
            _context.Thirst = 0.0f;
            _context.Bladder = 0.0f;
        }
    }

}