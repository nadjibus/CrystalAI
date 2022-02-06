// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// BehaviourTransition.cs is part of Crystal AI.
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
    /// BehaviourTransition is an <see cref="T:Crystal.IAction"/> which when executed triggers
    /// the selection of an <see cref="T:Crystal.IAction"/> using a linked 
    /// <see cref="T:Crystal.IBehaviour"/>.
    /// </summary>
    /// <seealso cref="T:Crystal.ActionBase" />
    /// <seealso cref="T:Crystal.ITransition" />
    public sealed class BehaviourTransition : ActionBase, ITransition
    {
        Behaviour _behaviour;
        IBehaviourCollection _behaviourCollection;
        string _behaviourId;

        /// <summary>
        /// The <see cref="T:Crystal.IBehaviour"/> used for <see cref="T:Crystal.IAction"/> selection
        /// when this action is selected. 
        /// </summary>
        /// <exception cref="Crystal.BehaviourTransition.BehaviourDoesNotExistException"></exception>
        public Behaviour Behaviour
        {
            get
            {
                if (_behaviour != null)
                    return _behaviour;

                if (string.IsNullOrEmpty(_behaviourId) ||
                   _behaviourCollection.Contains(_behaviourId) == false)
                    throw new BehaviourDoesNotExistException(_behaviourId);

                _behaviour = _behaviourCollection.Create(_behaviourId) as Behaviour;
                return _behaviour;
            }
            set { _behaviour = value ?? _behaviour; }
        }

        /// <summary>
        /// Triggers the action selection mechanism of the associated <see cref="T:Crystal.IBehaviour" /> or
        /// <see cref="T:Crystal.IUtilityAi" />.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public IAction Select(IContext context)
        {
            return Behaviour.Select(context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviourTransition"/> class.
        /// </summary>
        internal BehaviourTransition()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviourTransition"/> class.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        /// <exception cref="Crystal.BehaviourTransition.BehaviourNullException"></exception>
        public BehaviourTransition(Behaviour behaviour)
        {
            if (behaviour == null)
                throw new BehaviourNullException();

            _behaviour = behaviour;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviourTransition"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="behaviourId">The behaviour identifier.</param>
        /// <param name="collection">The collection.</param>
        /// <exception cref="Crystal.ActionBase.NameIdEmptyOrNullException"></exception>
        public BehaviourTransition(string nameId, string behaviourId, IBehaviourCollection collection)
          : base(nameId, collection?.Options?.Actions)
        {
            if (string.IsNullOrEmpty(behaviourId))
                throw new NameIdEmptyOrNullException();

            _behaviourId = behaviourId;
            _behaviourCollection = collection;
        }

        internal class BehaviourNullException : Exception
        {
        }

        internal class BehaviourDoesNotExistException : Exception
        {
            string _message;

            public override string Message
            {
                get { return _message; }
            }

            public BehaviourDoesNotExistException(string nameId)
            {
                _message = string.Format("Error: {0} does not exist in the Behaviour collection!", nameId);
            }
        }
    }

}