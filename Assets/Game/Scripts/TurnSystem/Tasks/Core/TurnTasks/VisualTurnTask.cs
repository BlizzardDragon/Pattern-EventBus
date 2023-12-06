namespace Roguelike_EventBus
{
    public sealed class VisualTurnTask : TurnPipelineTask<VisualTask, VisualPipeline>
    {
        public VisualTurnTask(VisualPipeline tPipeline) : base(tPipeline)
        {
        }

        public override void OnTurnPipelineTaskFinished()
        {
            _tPipeline.Clear();
        }
    }
}