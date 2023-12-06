using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public class PlayerFireEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public PlayerFireEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}