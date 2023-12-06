using Declarative;
using Roguelike_EventBus.Common.Model;

namespace Roguelike_EventBus
{
    public sealed class BarrelModel : DeclarativeModel
    {
        [Section]
        public Position Position;

        [Section]
        public Attack Attack;

        [Section]
        public Stats Stats;

        [Section]
        public Life Life;
    }
}