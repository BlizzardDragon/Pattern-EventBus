

namespace Roguelike_EventBus
{
    public class CollideVisualHandler : BaseVisualHandler<CollideEvent>
    {
        public CollideVisualHandler(
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService) { }


        protected override void HandleEvent(CollideEvent evt)
        {
            var sourcePosition = evt.FirstEntity.Get<PositionComponent>().Value;
            var targetPosition = evt.SecondEntity.Get<PositionComponent>().Value;
            var offset = (targetPosition - sourcePosition) * 0.5f;

            _visualPipeline.AddTask(new MoveVisualTask(
                evt.FirstEntity,
                sourcePosition + offset,
                _valueService.CommonAnimationDuration / 2));

            _visualPipeline.AddTask(new MoveVisualTask(
                evt.FirstEntity,
                sourcePosition,
                _valueService.CommonAnimationDuration / 2));
        }
    }
}