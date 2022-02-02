// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ConsiderationBase.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System;


namespace Crystal
{

    /// <summary>
    ///   Base class for considerations.
    /// </summary>
    /// <seealso cref="T:Crystal.IConsideration"/>
    public abstract class ConsiderationBase : IConsideration
    {
        IConsiderationCollection _collection;
        float _weight = 1.0f;

        /// <summary>
        ///   Use this for the internal <see cref="T:Crystal.IEvaluator"/>. Note that if you don't use
        ///   this field but define and use a variable of your own,
        ///   then <see cref="P:Crystal.ConsiderationBase.IsInverted"/> will not function as intended
        ///   as there is no way of knowing a-priori what that variable may be.
        /// </summary>
        protected IEvaluator Evaluator;

        /// <summary>
        ///   An identifier for this consideration.
        /// </summary>
        public string NameId { get; set; }

        /// <summary>
        ///   Gets or sets the default utility.
        /// </summary>
        public Utility DefaultUtility { get; set; }

        /// <summary>
        ///   Returns the utility for this consideration.
        /// </summary>
        /// <value>The utility.</value>
        public Utility Utility { get; protected set; }

        /// <summary>
        ///   The weight of this consideration.
        /// </summary>
        public float Weight
        {
            get { return _weight; }
            set { _weight = value.Clamp01(); }
        }

        /// <summary>
        ///   If true, then the output of the associated evaluator is inverted, in effect inverting the
        ///   consideration.
        /// </summary>
        public bool IsInverted
        {
            get
            {
                return Evaluator != null && Evaluator.IsInverted;
            }
            set
            {
                if (Evaluator == null)
                    return;

                Evaluator.IsInverted = value;
            }
        }

        /// <summary>Calculates the utility given the specified context.</summary>
        /// <param name="context">The context.</param>
        public abstract void Consider(IContext context);

        /// <summary>
        /// Creates a new instance of the implementing class. Note that the semantics here
        /// are somewhat vague, however, by convention the "Prototype Pattern" uses a "Clone"
        /// function. Note that this may have very different semantics when compared with either
        /// shallow or deep cloning. When implementing this remember to include only the defining
        /// characteristics of the class and not its state!
        /// </summary>
        /// <returns></returns>
        public abstract IConsideration Clone();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Crystal.ConsiderationBase"/> class.
        /// </summary>
        protected ConsiderationBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Crystal.ConsiderationBase"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        protected ConsiderationBase(ConsiderationBase other)
        {
            _collection = other._collection;
            NameId = other.NameId;
            DefaultUtility = other.DefaultUtility;
            Utility = other.Utility;
            Weight = other.Weight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Crystal.ConsiderationBase"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="collection">The collection.</param>
        /// <exception cref="T:Crystal.ConsiderationBase.ConsiderationCollectionNullException"></exception>
        /// <exception cref="T:Crystal.ConsiderationBase.ConsiderationAlreadyExistsInCollectionException"></exception>
        protected ConsiderationBase(string nameId, IConsiderationCollection collection)
        {
            if (collection == null)
                throw new ConsiderationCollectionNullException();

            NameId = nameId;
            _collection = collection;
            if (_collection.Add(this) == false)
                throw new ConsiderationAlreadyExistsInCollectionException(nameId);
        }

        internal class ConsiderationCollectionNullException : Exception
        {
        }

        internal class ConsiderationAlreadyExistsInCollectionException : Exception
        {
            string _message;

            public override string Message
            {
                get { return _message; }
            }

            public ConsiderationAlreadyExistsInCollectionException(string msg)
            {
                _message = string.Format("{0} already exists in the consideration collection", msg);
            }
        }
    }

}