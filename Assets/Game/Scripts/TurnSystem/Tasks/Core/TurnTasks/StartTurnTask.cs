using System;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("TurnStarted!");
            Finish();
        }
    }
}