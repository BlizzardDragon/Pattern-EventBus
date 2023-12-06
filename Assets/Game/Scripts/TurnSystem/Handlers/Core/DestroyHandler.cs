

namespace Roguelike_EventBus
{
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        private readonly LevelMap _levelMap;
        
        public DestroyHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }
        
        protected override void HandleEvent(DestroyEvent evt)
        {
            if (evt.Entity.TryGet(out DeathComponent deathComponent))
            {
                deathComponent.Die();
            }

            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            _levelMap.EntityMap.RemoveEntity(coordinates.Value, evt.Entity);
        }
    }
}