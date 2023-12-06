using System;
using Entities;

namespace Roguelike_EventBus
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        
        public int extraDamage;
    }
}