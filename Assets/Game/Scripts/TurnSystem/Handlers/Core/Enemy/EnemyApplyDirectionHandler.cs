using System.Collections.Generic;
using System.Linq;
using Entities;
using Roguelike_EventBus;
using Roguelike_EventBus.Enemy;
using Roguelike_EventBus.Player;

using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class EnemyApplyDirectionHandler : BaseHandler<EnemyApplyDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public EnemyApplyDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(EnemyApplyDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            Vector2Int targetCoordinates = coordinates.Value + evt.Direction;
            List<IEntity> targetEntities = _levelMap.EntityMap.GetEntities(targetCoordinates);
            List<PlayerEntity> targets = targetEntities.OfType<PlayerEntity>().ToList();

            if (targets.Any())
            {
                EventBus.RaiseEvent(new AttackEvent(evt.Entity, targets[0]));
                return;
            }

            EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates));
        }
    }
}