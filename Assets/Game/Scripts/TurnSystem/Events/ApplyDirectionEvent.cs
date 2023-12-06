using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public class ApplyDirectionEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public ApplyDirectionEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}