using Roguelike_EventBus.Config;
using Lessons.Utils;

namespace Roguelike_EventBus
{
    public sealed class WeaponComponent
    {
        public Weapon Value => _weapon;
        
        private readonly AtomicVariable<Weapon> _weapon;
        
        public WeaponComponent(AtomicVariable<Weapon> weapon)
        {
            _weapon = weapon;
        }
    }
}