using System;
using Lessons.Utils;

namespace Roguelike_EventBus.Common.Model
{
    [Serializable]
    public sealed class Stats
    {
        public AtomicVariable<int> Strength = 1;
    }
}