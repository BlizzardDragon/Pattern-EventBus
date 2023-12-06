using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public readonly struct SpawnEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;
        public readonly SpawnTypes Type;


        public SpawnEvent(SpawnTypes type, IEntity entity = default, Vector2Int direction = default)
        {
            Entity = entity;
            Direction = direction;
            Type = type;
        }
    }
}