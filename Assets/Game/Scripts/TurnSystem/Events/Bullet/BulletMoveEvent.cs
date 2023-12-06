using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public readonly struct BulletMoveEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Coordinates;
        public readonly bool IsForced;

        public BulletMoveEvent(IEntity entity, Vector2Int coordinates, bool isForced = false)
        {
            Entity = entity;
            Coordinates = coordinates;
            IsForced = isForced;
        }
    }
}