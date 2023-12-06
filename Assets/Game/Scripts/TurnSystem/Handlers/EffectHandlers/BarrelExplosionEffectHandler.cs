using Roguelike_EventBus;

namespace Roguelike_EventBus
{
    public sealed class BarrelExplosionEffectHandler : BaseHandler<BarrelExplosionEffectEvent>
    {
        public BarrelExplosionEffectHandler(EventBus eventBus) : base(eventBus)
        {

        }

        protected override void HandleEvent(BarrelExplosionEffectEvent evt)
        {
            foreach (var target in evt.AreaTargets)
            {
                EventBus.RaiseEvent(new ForceDirectionEvent(target.Item1, target.Item2));
                EventBus.RaiseEvent(new DealDamageEvent(target.Item1, evt.ExplosionDamage));
            }
            
            foreach (var target in evt.EpicentrTargets)
            {
                EventBus.RaiseEvent(new DealDamageEvent(target, evt.EpicentrDamage));
            }
        }
    }
}