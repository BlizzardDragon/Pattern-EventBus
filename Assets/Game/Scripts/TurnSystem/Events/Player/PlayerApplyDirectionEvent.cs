using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public class PlayerApplyDirectionEvent : ApplyDirectionEvent
    {
        public PlayerApplyDirectionEvent(IEntity entity, Vector2Int direction) : base(entity, direction)
        {
        }
    }
}