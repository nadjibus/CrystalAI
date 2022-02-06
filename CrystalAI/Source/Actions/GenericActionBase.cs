// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// GenericActionBase.cs is part of Crystal AI.
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
    ///   Base class for generic <see cref="T:Crystal.IAction"/>s. All actions should derive either from
    ///   this class or its non-generic version <see cref="T:Crystal.ActionBase"/>.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="T:Crystal.IAction"/>
    public class ActionBase<TContext> : IAction where TContext : class, IContext
    {
        readonly IActionCollection _collection;
        readonly ITimeProvider _timeProvider;
        float _cooldown;

        /// <summary>
        ///   A unique identifier for this action.
        /// </summary>
        public string NameId { get; }

        /// <summary>
        ///   The required cool-down time, in seconds, needed before this action executes again.
        /// </summary>
        public float CooldownTime
        {
            get { return _cooldown; }
            set { _cooldown = value.ClampToLowerBound(0.0f); }
        }

        /// <summary>
        ///   Executes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Execute(TContext context)
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
            EndInSuccess((TContext)context);
        }

        /// <summary>
        ///   Ends the action and sets its status to <see cref="F:Crystal.ActionStatus.Failure"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        protected void EndInFailure(IContext context)
        {
            EndInFailure((TContext)context);
        }

        /// <summary>
        ///   Ends the action and sets its status to <see cref="F:Crystal.ActionStatus.Success"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        protected void EndInSuccess(TContext context)
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
        protected void EndInFailure(TContext context)
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
        protected virtual void OnExecute(TContext context)
        {
            EndInSuccess(context);
        }

        /// <summary>
        ///   Executes on every action update, until <see cref="ActionBase.EndInSuccess"/> or
        ///   <see cref="ActionBase.EndInFailure"/> is called.
        /// </summary>
        /// <param name="context">Context.</param>
        protected virtual void OnUpdate(TContext context)
        {
        }

        /// <summary>
        ///   This can be used for cleanup. It executes after <see cref="ActionBase.EndInSuccess"/> or
        ///   <see cref="ActionBase.EndInFailure"/> is called.
        /// </summary>
        /// <param name="context">Context.</param>
        protected virtual void OnStop(TContext context)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ActionBase{TContext}"/> class.
        /// </summary>
        public ActionBase(ITimeProvider timeProvider = null)
        {
            _timeProvider = timeProvider ?? CrTime.Instance;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ActionBase{TContext}"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        protected ActionBase(ActionBase<TContext> other) : this()
        {
            NameId = other.NameId;
            CooldownTime = other.CooldownTime;
            _collection = other._collection;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ActionBase{TContext}"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="collection">The collection.</param>
        /// <exception cref="T:Crystal.ActionBase`1.NameIdEmptyOrNullException"></exception>
        /// <exception cref="T:Crystal.ActionBase`1.ActionCollectionNullException"></exception>
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

        void IAction.Execute(IContext context)
        {
            Execute((TContext)context);
        }

        bool CanExecute(TContext context)
        {
            if (InCooldown(context))
            {
                context.CurrentActionState.SetExecutionResult(ActionExecutionResult.Failure);
                return false;
            }

            return true;
        }

        bool TryUpdate(TContext context)
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

        void FinalizeAction(TContext context)
        {
            OnStop(context);
        }

        void AddSelfToCollection()
        {
            if (_collection.Add(this) == false)
                throw new ActionAlreadyExistsInCollectionException(NameId);
        }

        bool IAction.InCooldown(IContext context)
        {
            return InCooldown((TContext)context);
        }

        public bool InCooldown(TContext context)
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
            public override string Message { get; }

            public ActionAlreadyExistsInCollectionException(string nameId)
            {
                Message = string.Format("Error: {0} already exists in the actions collection.", nameId);
            }
        }
    }

}