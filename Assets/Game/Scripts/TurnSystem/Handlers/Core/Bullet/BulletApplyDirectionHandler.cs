using System.Collections.Generic;
using System.Linq;
using Entities;
using Roguelike_EventBus;
using Roguelike_EventBus.Enemy;

using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class BulletApplyDirectionHandler : BaseHandler<BulletApplyDirectionEvent>
    {
        private readonly LevelMap _levelMap;
        private readonly TurnPipeline<Task> _turnPipeline;

        public BulletApplyDirectionHandler(
            TurnPipeline<Task> turnPipeline,
            EventBus eventBus,
            LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
            _turnPipeline = turnPipeline;
        }


        protected override void HandleEvent(BulletApplyDirectionEvent evt)
        {
            var currentCoordinates = evt.Entity.Get<CoordinatesComponent>().Value;
            Vector2Int targetCoordinates = currentCoordinates + evt.Direction;
            List<IEntity> targetEntities = _levelMap.EntityMap.GetEntities(targetCoordinates);
            var targets = targetEntities.Where(entity => entity is EnemyEntity || entity is BarrelEntity).ToList();

            if (targets.Any())
            {
                EventBus.RaiseEvent(new BulletHitEvent(evt.Entity, targets[0]));

                foreach (var target in targets)
                {
                    EventBus.RaiseEvent(new AttackEvent(evt.Entity, target, false));
                }

                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));

                return;
            }

            EventBus.RaiseEvent(new BulletMoveEvent(evt.Entity, targetCoordinates));

            if (_levelMap.TileMap.IsWalkable(targetCoordinates))
            {
                _turnPipeline.CancelTurn();
            }
        }
    }
}