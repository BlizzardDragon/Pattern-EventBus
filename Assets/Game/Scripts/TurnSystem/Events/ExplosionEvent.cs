using Entities;

namespace Roguelike_EventBus
{
    public readonly struct ExplosionEvent
    {
        public readonly IEntity Entity;

        public ExplosionEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}