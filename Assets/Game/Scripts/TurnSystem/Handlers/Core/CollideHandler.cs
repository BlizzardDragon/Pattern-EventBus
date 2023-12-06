using Roguelike_EventBus;

namespace Roguelike_EventBus
{
    public sealed class CollideHandler : BaseHandler<CollideEvent>
    {
        public CollideHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(CollideEvent evt)
        {
            EventBus.RaiseEvent(new DealDamageEvent(evt.FirstEntity, 1));
            EventBus.RaiseEvent(new DealDamageEvent(evt.SecondEntity, 1));
        }
    }
}