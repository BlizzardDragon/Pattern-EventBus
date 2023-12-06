using DG.Tweening;

using UnityEngine;

namespace Roguelike_EventBus
{
    public class BulletMoveVisualHandler : BaseVisualHandler<BulletMoveEvent>
    {
        private readonly LevelMap _levelMap;

        public BulletMoveVisualHandler(
            LevelMap levelMap,
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(BulletMoveEvent evt)
        {
            Vector3 targetPosition = _levelMap.TileMap.CoordinatesToPosition(evt.Coordinates);
            _visualPipeline.AddTask(new MoveVisualTask(
                evt.Entity,
                targetPosition,
                _valueService.BulletAnimationDuration,
                evt.IsForced,
                Ease.Linear));
        }
    }
}