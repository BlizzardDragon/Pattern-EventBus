using System.Collections.Generic;
using System.Linq;
using Entities;


namespace Roguelike_EventBus
{
    public sealed class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public ForceDirectionHandler(LevelMap levelMap, EventBus eventBus) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + evt.Direction;
            List<IEntity> targetEntities = _levelMap.EntityMap.GetEntities(targetCoordinates);

            if (evt.Entity is BarrelEntity) return;

            if (targetEntities.Any())
            {
                foreach (var targetEntity in targetEntities)
                {
                    EventBus.RaiseEvent(new CollideEvent(evt.Entity, targetEntity));
                }
            }
            else
            {
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates, true));
            }
        }
    }
}