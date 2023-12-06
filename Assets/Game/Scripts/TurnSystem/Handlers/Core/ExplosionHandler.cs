using System.Collections.Generic;
using Entities;
using Roguelike_EventBus.Config;

using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class ExplosionHandler : BaseHandler<ExplosionEvent>
    {
        private readonly LevelMap _levelMap;

        public ExplosionHandler(LevelMap levelMap, EventBus eventBus) : base(eventBus)
        {
            _levelMap = levelMap;
        }


        protected override void HandleEvent(ExplosionEvent evt)
        {
            Explosion explosion = evt.Entity.Get<ExplosionComponent>().Value;
            Vector2Int currentCoordinate = evt.Entity.Get<CoordinatesComponent>().Value;
            EntityMap entityMap = _levelMap.EntityMap;

            foreach (var effect in explosion.ExplosionEffects)
            {
                Vector2Int[] directions = new Vector2Int[]
                {
                    Vector2Int.up,
                    Vector2Int.down,
                    Vector2Int.left,
                    Vector2Int.right
                };

                List<(IEntity, Vector2Int, int)> targets = new();

                for (int i = 0; i < effect.Radius; i++)
                {
                    for (int j = 0; j < directions.Length; j++)
                    {
                        Vector2Int targetCoordinate = currentCoordinate + directions[j] * (i + 1);
                        List<IEntity> entities = entityMap.GetEntities(targetCoordinate);

                        foreach (var entity in entities)
                        {
                            (IEntity entity, Vector2Int direction, int distance) data = (entity, directions[j], i + 1);
                            targets.Add(data);
                        }
                    }
                }

                effect.EpicentrTargets = entityMap.GetEntities(currentCoordinate);
                effect.AreaTargets = targets;
                effect.Source = evt.Entity;
                EventBus.RaiseEvent(effect);
            }
        }
    }
}