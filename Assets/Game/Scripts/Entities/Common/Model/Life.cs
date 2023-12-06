using System;
using Lessons.Utils;

namespace Roguelike_EventBus.Common.Model
{
    [Serializable]
    public sealed class Life
    {
        public AtomicVariable<bool> IsDead = false;

        public AtomicVariable<int> HitPoints = 1;
        public AtomicVariable<int> MaxHitPoints = 1;
    }
}