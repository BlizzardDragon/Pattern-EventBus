using Declarative;
using Roguelike_EventBus.Common.Model;

namespace Roguelike_EventBus.Enemy
{
    public sealed class EnemyModel : DeclarativeModel
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