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
        Dictionary<int, ActionStatus> _actionStatusMap = new Dictionary<int, ActionStatus>();

        /// <summary>
        ///   Returns the sequence of actions executed when this sequence is selected.
        /// </summary>
        public IList<IAction> Actions
        {
            get { return _actions; }
        }

        /// <summary>
        /// Creates a new instance of the implementing class. Note that the semantics here
        /// are somewhat vague, however, by convention the "Prototype Pattern" uses a "Clone"
        /// function. Note that this may have very different semantics when compared with either
        /// shallow or deep cloning. When implementing this remember to include only the defining
        /// characteristics of the class and not its state!
        /// </summary>
        /// <returns></returns>
        public override IAction Clone()
        {
            return new ActionSequence(this);
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
                UpdateStatusMap(i);
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
                if (_actionStatusMap[i] != ActionStatus.Running)
                    continue;

                _actions[i].Execute(context);
                UpdateStatusMap(i);
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
        /// <param name="other">The other.</param>
        ActionSequence(ActionSequence other) : base(other)
        {
            _actions = new List<IAction>();
            _actionStatusMap = new Dictionary<int, ActionStatus>();

            for (int i = 0; i < other._actions.Count; i++)
            {
                var n = other._actions[i].Clone();
                _actions.Add(n);
                _actionStatusMap.Add(i, n.ActionStatus);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionSequence"/> class.
        /// </summary>
        /// <param name="nameId">The name identifier.</param>
        /// <param name="collection">The collection.</param>
        public ActionSequence(string nameId, IActionCollection collection) : base(nameId, collection)
        {
        }

        void UpdateStatusMap(int idx)
        {
            _actionStatusMap[idx] = _actions[idx].ActionStatus;
        }

        void ResolveActionStatusesThenEnd(IContext context)
        {
            if (_actionStatusMap.ContainsValue(ActionStatus.Running))
                return;

            if (_actionStatusMap.Values.All(s => s == ActionStatus.Success))
                EndInSuccess(context);
            else
                EndInFailure(context);
            _actionStatusMap.Clear();
        }
    }

}