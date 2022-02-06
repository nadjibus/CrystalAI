// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ActionSequence.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System.Collections.Generic;
using System.Linq;


namespace Crystal
{

    /// <summary>
    ///   An AI action that is comprised of one or more other actions, which are executed in order.
    /// </summary>
    /// <seealso cref="T:Crystal.ITransition"/>
    public sealed class ActionSequence : ActionBase
    {
        List<IAction> _actions = new List<IAction>(2);
        Dictionary<int, ActionExecutionResult> _actionStatusMap = new Dictionary<int, ActionExecutionResult>();

        /// <summary>
        ///   Returns the sequence of actions executed when this sequence is selected.
        /// </summary>
        public IList<IAction> Actions
        {
            get { return _actions; }
        }

        /// <summary>
        ///   Executes each child action in sequence.
        /// </summary>
        /// <param name="context">Context.</param>
        protected override void OnExecute(IContext context)
        {
            int count = _actions.Count;
            for (int i = 0; i < count; i++)
            {
                _actions[i].Execute(context);
                UpdateStatusMap(i, context);
            }

            ResolveActionStatusesThenEnd(context);
        }

        /// <summary>
        ///   Updates each action in sequence until no action is running.
        /// </summary>
        /// <param name="context">Context.</param>
        protected override void OnUpdate(IContext context)
        {
            int count = _actions.Count;
            for (int i = 0; i < count; i++)
            {
                if (_actionStatusMap[i] != ActionExecutionResult.Running)
                    continue;

                _actions[i].Execute(context);
                UpdateStatusMap(i, context);
            }

            ResolveActionStatusesThenEnd(context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionSequence"/> class.
        /// </summary>
        public ActionSequence()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionSequence"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="collection">The collection.</param>
        public ActionSequence(string nameId, IActionCollection collection) : base(nameId, collection)
        {
        }

        void UpdateStatusMap(int idx, IContext context)
        {
            _actionStatusMap[idx] = context.CurrentActionState.ExecutionResult;
        }

        void ResolveActionStatusesThenEnd(IContext context)
        {
            if (_actionStatusMap.ContainsValue(ActionExecutionResult.Running))
                return;

            if (_actionStatusMap.Values.All(s => s == ActionExecutionResult.Success))
                EndInSuccess(context);
            else
                EndInFailure(context);
            _actionStatusMap.Clear();
        }
    }

}