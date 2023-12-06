using Declarative;
using Roguelike_EventBus.Common.Model;

namespace Roguelike_EventBus.Player
{
    public sealed class PlayerModel : DeclarativeModel
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