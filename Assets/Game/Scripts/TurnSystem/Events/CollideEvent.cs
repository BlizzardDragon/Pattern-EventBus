using Entities;

namespace Roguelike_EventBus
{
    public class CollideEvent
    {
        public readonly IEntity FirstEntity;
        public readonly IEntity SecondEntity;

        public CollideEvent(IEntity firstEntity, IEntity secondEntity )
        {
            FirstEntity = firstEntity;
            SecondEntity = secondEntity;
        }
    }
}