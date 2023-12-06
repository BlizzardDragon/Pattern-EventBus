

namespace Roguelike_EventBus
{
    public sealed class PlayerFireHandler : BaseHandler<PlayerFireEvent>
    {
        private readonly TurnPipeline<Task> _turnPipeline;
        private readonly LevelMap _levelMap;

        public PlayerFireHandler(
            TurnPipeline<Task> turnPipeline,
            LevelMap levelMap,
            EventBus eventBus) : base(eventBus)
        {
            _turnPipeline = turnPipeline;
            _levelMap = levelMap;
        }


        protected override void HandleEvent(PlayerFireEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>().Value;
            var targetCoordinates = coordinates + evt.Direction;

            if (_levelMap.TileMap.IsWalkable(targetCoordinates))
            {
                EventBus.RaiseEvent(new SpawnEvent(SpawnTypes.Bullet, evt.Entity, evt.Direction));
            }
            else
            {
                _turnPipeline.CancelTurn();
            }
        }
    }
}