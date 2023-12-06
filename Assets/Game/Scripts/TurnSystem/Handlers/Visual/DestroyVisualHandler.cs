

namespace Roguelike_EventBus
{
    public class DestroyVisualHandler : BaseVisualHandler<DestroyEvent>
    {
        private readonly LevelMap _levelMap;
        public DestroyVisualHandler(
            LevelMap levelMap,
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService)
        {
            _levelMap = levelMap;
        }


        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualPipeline.AddTask(new DestroyVisualTask(evt.Entity, _valueService.CommonAnimationDuration, _levelMap));
        }
    }
}