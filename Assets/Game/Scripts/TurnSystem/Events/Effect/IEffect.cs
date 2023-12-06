using Entities;

namespace Roguelike_EventBus
{
    public interface IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}