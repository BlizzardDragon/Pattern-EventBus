using DG.Tweening;

using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class BulletHitVisualHandler : BaseVisualHandler<BulletHitEvent>
    {
        private readonly LevelMap _levelMap;

        public BulletHitVisualHandler(
            LevelMap levelMap,
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService)
        {
            _levelMap = levelMap;
        }


        protected override void HandleEvent(BulletHitEvent evt)
        {
            Vector3 targetPosition = 
                _levelMap.TileMap.CoordinatesToPosition(evt.Target.Get<CoordinatesComponent>().Value);

            _visualPipeline.AddTask(new MoveVisualTask(
                evt.Entity,
                targetPosition,
                _valueService.BulletAnimationDuration, 
                false,
                Ease.OutSine));
        }
    }
}