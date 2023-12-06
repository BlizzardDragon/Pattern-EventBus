using System;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("TurnFinished!");
            Finish();
        }
    }
}