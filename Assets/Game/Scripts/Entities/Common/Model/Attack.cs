using System;
using Roguelike_EventBus.Config;
using Lessons.Utils;

namespace Roguelike_EventBus.Common.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<Weapon> Weapon;
        public AtomicVariable<Explosion> Explosion;
    }
}