using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roguelike_EventBus
{
    public class EnemyTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly TileMap _tileMap;
        private readonly IEntity _target;
        private IEntity _entity;

        public EnemyTask(EventBus eventBus, LevelMap levelMap, PlayerService playerService)
        {
            _eventBus = eventBus;
            _tileMap = levelMap.TileMap;
            _target = playerService.Player;
        }


        public void InstallEntity(IEntity entity) => _entity = entity;

        protected override void OnRun()
        {
            Vector2Int nextStep = FindNextStep(
                _entity.Get<CoordinatesComponent>().Value,
                _target.Get<CoordinatesComponent>().Value,
                _tileMap);

            _eventBus.RaiseEvent(new EnemyApplyDirectionEvent(_entity, nextStep));
            Finish();
        }

        private Vector2Int FindNextStep(Vector2Int currentCoordinate, Vector2Int targerCoordinate, TileMap tileMap)
        {
            List<Vector2Int> availableDirections = new()
            {
                new Vector2Int(0, 1),
                new Vector2Int(0, -1),
                new Vector2Int(-1, 0),
                new Vector2Int(1, 0)
            };

            Vector2Int direction = targerCoordinate - currentCoordinate;

            Vector2Int nearestDirection;
            Vector2Int alternativeDirection;
            Vector2Int distantDirection;

            int absX = Mathf.Abs(direction.x);
            int absY = Mathf.Abs(direction.y);

            if (absX > absY)
            {
                nearestDirection = direction.x > 0 ? Vector2Int.right : Vector2Int.left;
                alternativeDirection = direction.y > 0 ? Vector2Int.up : Vector2Int.down;

            }
            else if (absX < absY)
            {
                nearestDirection = direction.y > 0 ? Vector2Int.up : Vector2Int.down;
                alternativeDirection = direction.x > 0 ? Vector2Int.right : Vector2Int.left;
            }
            else
            {
                // direction = Vector2Int.zero.
                if (absX == 0)
                {
                    Debug.Log($"Direction = {direction}! (Vector2Int.zero)");
                    return Vector2Int.zero;
                }

                // Нормализация и сохранение знака при отрицательных значениях.
                var direction_1 = new Vector2Int(direction.x / Math.Abs(direction.x), 0);
                var direction_2 = new Vector2Int(0, direction.y / Math.Abs(direction.y));

                if (Random.Range(0, 2) == 0)
                {
                    nearestDirection = direction_1;
                    alternativeDirection = direction_2;
                }
                else
                {
                    nearestDirection = direction_2;
                    alternativeDirection = direction_1;
                }
            }

            distantDirection = -nearestDirection;

            // Обхождение углов.
            if (direction.x != 0 && direction.y != 0)
            {
                if (tileMap.IsWalkable(currentCoordinate + nearestDirection))
                {
                    return nearestDirection;
                }
                else
                {
                    availableDirections.Remove(nearestDirection);

                    if (tileMap.IsWalkable(currentCoordinate + alternativeDirection))
                    {
                        return alternativeDirection;
                    }
                    else
                    {
                        availableDirections.Remove(alternativeDirection);
                        availableDirections.Remove(distantDirection);

                        if (tileMap.IsWalkable(currentCoordinate + availableDirections[0]))
                        {
                            return availableDirections[0];
                        }
                        else
                        {
                            if (tileMap.IsWalkable(currentCoordinate + distantDirection))
                            {
                                return distantDirection;
                            }
                            else
                            {
                                throw new Exception("The entity is surrounded!");
                            }
                        }
                    }
                }
            }

            // Попытка движения по прямой линии.
            if (tileMap.IsWalkable(currentCoordinate + nearestDirection))
            {
                return nearestDirection;
            }
            else
            {
                availableDirections.Remove(nearestDirection);
                availableDirections.Remove(distantDirection);
            }

            int randomIndex = Random.Range(0, availableDirections.Count);

            if (tileMap.IsWalkable(currentCoordinate + availableDirections[randomIndex]))
            {
                return availableDirections[randomIndex];
            }
            else
            {
                availableDirections.Remove(availableDirections[randomIndex]);

                if (tileMap.IsWalkable(currentCoordinate + availableDirections[0]))
                {
                    return availableDirections[0];
                }
                else
                {
                    if (tileMap.IsWalkable(currentCoordinate + distantDirection))
                    {
                        return distantDirection;
                    }
                    else
                    {
                        throw new Exception("The entity is surrounded!");
                    }
                }
            }
        }
    }
}
