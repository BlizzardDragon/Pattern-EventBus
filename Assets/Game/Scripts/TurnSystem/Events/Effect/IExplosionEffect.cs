using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public interface IExplosionEffect
    {
        public IEntity Source { get; set; }
        public List<IEntity> EpicentrTargets { get; set; }
        public List<(IEntity, Vector2Int, int)> AreaTargets { get; set; }
        public int Radius { get; set; }
    }
}