// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ActionBase.cs is part of Crystal AI.
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
    ///   Base class for non-generic <see cref="T:Crystal.IAction"/>s. All actions should derive either from
    ///   this class or its generic version <see cref="T:Crystal.ActionBase`1"/>.
    /// </summary>
    /// <seealso cref="T:Crystal.IAction"/>
    public class ActionBase : IAction
    {
        IActionCollection _collection;
        float _cooldown;
        readonly ITimeProvider _timeProvider;

        /// <summary>
        ///   A string alias for ID.
        /// </summary>
        public string NameId { get; set; }

        /// <summary>
        ///   The required cool-down time, in seconds, needed before this action executes again.
        /// </summary>
        public float CooldownTime
        {
            get { return _cooldown; }
            set { _cooldown = value.ClampToLowerBound(0.0f); }
        }

        /// <summary>Executes the action.</summary>
        /// <param name="context">The context.</param>
        public void Execute(IContext context)
        {
            if (!CanExecute(context))
                return;

            if (TryUpdate(context))
                return;

            context.CurrentActionState.SetAction(this, _timeProvider.TotalSeconds);
            context.CurrentActionState.SetExecutionResult(ActionExecutionResult.Running);
            OnExecute(context);
        }

        /// <summary>
        ///   Ends the action and sets its status to <see cref="F:Crystal.ActionStatus.Success"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        protected void EndInSuccess(IContext context)
        {
            if (context.CurrentActionState.ExecutionResult != ActionExecutionResult.Running)
                return;

            context.CurrentActionState.SetExecutionResult(ActionExecutionResult.Success);
            FinalizeAction(context);
        }

        /// <summary>
        ///   Ends the action and sets its status to <see cref="F:Crystal.ActionStatus.Failure"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        protected void EndInFailure(IContext context)
        {
            if (context.CurrentActionState.ExecutionResult != ActionExecutionResult.Running)
                return;

            context.CurrentActionState.SetExecutionResult(ActionExecutionResult.Failure);
            FinalizeAction(context);
        }

        /// <summary>
        ///   Executes once when the action starts.
        /// </summary>
        /// <param name="context">Context.</param>
        protected virtual void OnExecute(IContext context)
        {
            EndInSuccess(context);
        }

        /// <summary>
        ///   Executes on every action update, until <see cref="ActionBase.EndInSuccess"/> or
        ///   <see cref="ActionBase.EndInFailure"/> is called.
        /// </summary>
        /// <param name="context">Context.</param>
        protected virtual void OnUpdate(IContext context)
        {
        }

        /// <summary>
        ///   This can be used for cleanup. It executes after <see cref="ActionBase.EndInSuccess"/> or
        ///   <see cref="ActionBase.EndInFailure"/> is called.
        /// </summary>
        /// <param name="context">Context.</param>
        protected virtual void OnStop(IContext context)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ActionBase"/> class.
        /// </summary>
        public ActionBase(ITimeProvider timeProvider = null)
        {
            _timeProvider = timeProvider ?? CrTime.Instance;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ActionBase"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="collection">The collection.</param>
        /// <exception cref="Crystal.ActionBase.NameIdEmptyOrNullException"></exception>
        /// <exception cref="Crystal.ActionBase.ActionCollectionNullException"></exception>
        public ActionBase(string nameId, IActionCollection collection) : this()
        {
            if (string.IsNullOrEmpty(nameId))
                throw new NameIdEmptyOrNullException();
            if (collection == null)
                throw new ActionCollectionNullException();

            NameId = nameId;
            _collection = collection;
            AddSelfToCollection();
        }

        bool CanExecute(IContext context)
        {
            if (InCooldown(context))
            {
                context.CurrentActionState.SetExecutionResult(ActionExecutionResult.Failure);
                return false;
            }

            return true;
        }

        bool TryUpdate(IContext context)
        {
            if (context.CurrentActionState?.Action != this)
                return false;

            if (context.CurrentActionState.ExecutionResult == ActionExecutionResult.Running)
            {
                OnUpdate(context);
                return true;
            }

            return false;
        }

        void FinalizeAction(IContext context)
        {
            OnStop(context);
        }

        void AddSelfToCollection()
        {
            if (_collection.Add(this) == false)
                throw new ActionAlreadyExistsInCollectionException(NameId);
        }

        public bool InCooldown(IContext context)
        {
            if (context.CurrentActionState?.Action != this)
                return false;

            var state = context.CurrentActionState;

            if (state.ExecutionResult == ActionExecutionResult.Running || state.ExecutionResult == ActionExecutionResult.Idle)
                return false;

            return _timeProvider.TotalSeconds - state.StartedAt < _cooldown;
        }

        internal class NameIdEmptyOrNullException : Exception
        {
        }

        internal class ActionCollectionNullException : Exception
        {
        }

        internal class ActionAlreadyExistsInCollectionException : Exception
        {
            string _message;

            public override string Message
            {
                get { return _message; }
            }

            public ActionAlreadyExistsInCollectionException(string nameId)
            {
                _message = string.Format("Error: {0} already exists in the actions collection.", nameId);
            }
        }
    }

}