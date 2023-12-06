using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    [Serializable]
    public struct BarrelExplosionEffectEvent : IExplosionEffect
    {
        public IEntity Source { get; set; }
        public List<IEntity> EpicentrTargets { get; set; }
        public List<(IEntity, Vector2Int, int)>  AreaTargets { get; set; }
        [field: SerializeField] public int Radius { get; set; }
        public int ExplosionDamage;
        public int EpicentrDamage;
    }
}