

namespace Roguelike_EventBus
{
    public sealed class AttackVisualHandler : BaseVisualHandler<AttackEvent>
    {
        private readonly LevelMap _levelMap;

        public AttackVisualHandler(
            LevelMap levelMap,
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService)
        {
            _levelMap = levelMap;
        }


        protected override void HandleEvent(AttackEvent evt)
        {
            if (!evt.Animation) return;
            var sourcePosition = _levelMap.TileMap.CoordinatesToPosition(evt.Entity.Get<CoordinatesComponent>().Value);
            var targetPosition = _levelMap.TileMap.CoordinatesToPosition(evt.Target.Get<CoordinatesComponent>().Value);
            var offset = (targetPosition - sourcePosition) * 0.5f;

            _visualPipeline.AddTask(new MoveVisualTask(
                evt.Entity,
                sourcePosition + offset,
                _valueService.CommonAnimationDuration / 2));

            _visualPipeline.AddTask(new MoveVisualTask(
                evt.Entity,
                sourcePosition,
                _valueService.CommonAnimationDuration / 2));
        }
    }
}