
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class MoveVisualHandler : BaseVisualHandler<MoveEvent>
    {
        private readonly LevelMap _levelMap;

        public MoveVisualHandler(
            LevelMap levelMap,
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService)
        {
            _levelMap = levelMap;
        }


        protected override void HandleEvent(MoveEvent evt)
        {
            Vector3 targetPosition = _levelMap.TileMap.CoordinatesToPosition(evt.Coordinates);
            _visualPipeline.AddTask(new MoveVisualTask(
                evt.Entity,
                targetPosition,
                _valueService.CommonAnimationDuration,
                evt.IsForced));
        }
    }
}