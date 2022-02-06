using System;
using System.Collections.Generic;
using System.Text;

namespace Crystal
{
    public class ActionState
    {
        /// <summary>
        ///   The Action
        /// </summary>
        public IAction Action { get; private set; }

        /// <summary>
        ///   The Time in seconds when this action has started
        /// </summary>
        public float StartedAt { get; private set; }


        /// <summary>
        ///   Gets the action execution result.
        /// </summary>
        public ActionExecutionResult ExecutionResult { get; private set; } = ActionExecutionResult.Idle;

        public void SetAction(IAction action, float startedAt)
        {
            Action = action;
            StartedAt = startedAt;
        }

        public void SetExecutionResult(ActionExecutionResult result)
        {
            ExecutionResult = result;
        }
    }
}
