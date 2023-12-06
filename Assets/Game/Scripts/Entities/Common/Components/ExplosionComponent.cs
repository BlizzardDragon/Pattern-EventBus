using Roguelike_EventBus.Config;
using Lessons.Utils;

namespace Roguelike_EventBus
{
    public sealed class ExplosionComponent
    {
        public Explosion Value => _explosion;
        
        private readonly AtomicVariable<Explosion> _explosion;
        
        public ExplosionComponent(AtomicVariable<Explosion> explosion)
        {
            _explosion = explosion;
        }
    }
}