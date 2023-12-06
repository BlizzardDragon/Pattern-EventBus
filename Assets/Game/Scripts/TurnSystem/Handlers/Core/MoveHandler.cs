

namespace Roguelike_EventBus
{
    public sealed class MoveHandler : BaseHandler<MoveEvent>
    {
        private readonly LevelMap _levelMap;
        
        public MoveHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }
        
        protected override void HandleEvent(MoveEvent evt)
        {
            var coordinatesComponent = evt.Entity.Get<CoordinatesComponent>();            
            _levelMap.EntityMap.RemoveEntity(coordinatesComponent.Value, evt.Entity);
            _levelMap.EntityMap.SetEntity(evt.Coordinates, evt.Entity);
            coordinatesComponent.Value = evt.Coordinates;
            
            if (!_levelMap.TileMap.IsWalkable(evt.Coordinates))
            {
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
        }
    }
}