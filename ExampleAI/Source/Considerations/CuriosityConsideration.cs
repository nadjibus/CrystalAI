// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// CuriosityConsideration.cs is part of Crystal AI.
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

    public class CuriosityConsideration : ConsiderationBase<CharacterContext>
    {

        public static readonly string Name = "Curiosity";

        public override void Consider(CharacterContext context)
        {
            Utility = new Utility(0.01f, Weight);
        }

        public override IConsideration Clone()
        {
            return new CuriosityConsideration(this);
        }

        public CuriosityConsideration()
        {
        }

        CuriosityConsideration(CuriosityConsideration other) : base(other)
        {
        }

        public CuriosityConsideration(IConsiderationCollection collection)
          : base(Name, collection)
        {
        }
    }

}