

namespace Roguelike_EventBus
{
    public class DealDamageVisualHandler : BaseVisualHandler<DealDamageEvent>
    {
        public DealDamageVisualHandler(
            EventBus eventBus,
            VisualPipeline visualPipeline,
            VisualValueService valueService) : base(eventBus, visualPipeline, valueService)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            _visualPipeline.AddTask(new DealDemageVisualTask(evt.Entity, 0.125f));
        }
    }
}