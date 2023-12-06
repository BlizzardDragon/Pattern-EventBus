using Entities;

namespace Roguelike_EventBus
{
    public struct AttackEvent
    {
        public readonly IEntity Entity;
        public readonly IEntity Target;
        public bool Animation;

        public AttackEvent(IEntity entity, IEntity target, bool animation = true)
        {
            Entity = entity;
            Target = target;
            Animation = animation;
        }
    }
}