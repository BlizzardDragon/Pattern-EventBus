using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public class BulletApplyDirectionEvent : ApplyDirectionEvent
    {
        public BulletApplyDirectionEvent(IEntity entity, Vector2Int direction) : base(entity, direction)
        {
        }
    }
}