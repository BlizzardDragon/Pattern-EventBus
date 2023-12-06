using Roguelike_EventBus.Common.Model;

namespace Roguelike_EventBus
{
    public sealed class StatsComponent
    {
        public int Strength => _stats.Strength;
        
        private readonly Stats _stats;
        
        public StatsComponent(Stats stats)
        {
            _stats = stats;
        }
    }
}