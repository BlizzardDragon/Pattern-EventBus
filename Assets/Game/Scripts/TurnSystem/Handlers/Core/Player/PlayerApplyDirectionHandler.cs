using System.Collections.Generic;
using System.Linq;
using Entities;

using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class PlayerApplyDirectionHandler : BaseHandler<PlayerApplyDirectionEvent>
    {
        private readonly TurnPipeline<Task> _turnPipeline;
        private readonly LevelMap _levelMap;
        private int _cancelTurnCaunter;


        public PlayerApplyDirectionHandler(
            TurnPipeline<Task> turnPipeline,
            LevelMap levelMap,
            EventBus eventBus) : base(eventBus)
        {
            _turnPipeline = turnPipeline;
            _levelMap = levelMap;
        }

        protected override void HandleEvent(PlayerApplyDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            Vector2Int targetCoordinates = coordinates.Value + evt.Direction;
            List<IEntity> targetEntities = _levelMap.EntityMap.GetEntities(targetCoordinates);

            if (targetEntities.Any())
            {
                TrySkipTurn();
                return;
            }

            if (_levelMap.TileMap.IsWalkable(targetCoordinates))
            {
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates));
                _cancelTurnCaunter = 0;
            }
            else
            {
                TrySkipTurn();
            }
        }

        private void TrySkipTurn()
        {
            if (_cancelTurnCaunter > 0)
            {
                _cancelTurnCaunter = 0;
            }
            else
            {
                _turnPipeline.CancelTurn();
                _cancelTurnCaunter++;
            }
        }
    }
}