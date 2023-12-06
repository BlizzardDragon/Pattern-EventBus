using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public class EnemyApplyDirectionEvent : ApplyDirectionEvent
    {
        public EnemyApplyDirectionEvent(IEntity entity, Vector2Int direction) : base(entity, direction)
        {
        }
    }
}