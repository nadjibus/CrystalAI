// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ConstantUtilityOption.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


namespace Crystal
{

    /// <summary>
    ///   This option always returns the same utility irrespective of the context.
    ///   <seealso cref="T:Crystal.Option"/>
    /// </summary>
    public sealed class ConstantUtilityOption : Option
    {
        /// <summary>
        ///   Calculates the utility given the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The utility.</returns>
        public override void Consider(IContext context)
        {
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public override IConsideration Clone()
        {
            return new ConstantUtilityOption(this);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:Crystal.ConstantUtilityOption"/> class.
        /// </summary>
        public ConstantUtilityOption()
        {
            Weight = 1.0f;
            DefaultUtility = new Utility(0.0f, Weight);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Crystal.ConstantUtilityOption"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        ConstantUtilityOption(ConstantUtilityOption other) : base(other)
        {
            Weight = other.Weight;
            DefaultUtility = other.DefaultUtility;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantUtilityOption"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="collection">The collection.</param>
        public ConstantUtilityOption(string nameId, IOptionCollection collection) : base(nameId, collection)
        {
        }
    }

}