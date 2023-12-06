using Entities;

namespace Roguelike_EventBus
{
    public struct BulletHitEvent
    {
        public readonly IEntity Entity;
        public readonly IEntity Target;

        public BulletHitEvent(IEntity entity, IEntity target)
        {
            Entity = entity;
            Target = target;
        }
    }
}