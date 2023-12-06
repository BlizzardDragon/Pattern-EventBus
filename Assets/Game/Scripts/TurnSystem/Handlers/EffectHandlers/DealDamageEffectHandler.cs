

namespace Roguelike_EventBus
{
    public sealed class DealDamageEffectHandler : BaseHandler<DealDamageEffectEvent>
    {
        public DealDamageEffectHandler(EventBus eventBus) : base(eventBus)
        {
            
        }
        
        protected override void HandleEvent(DealDamageEffectEvent evt)
        {
            var damage = evt.extraDamage;

            if (evt.Source.TryGet(out StatsComponent stats))
            {
                damage += stats.Strength;
            }
            
            EventBus.RaiseEvent(new DealDamageEvent(evt.Target, damage));
        }
    }
}