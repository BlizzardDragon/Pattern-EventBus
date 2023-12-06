namespace Roguelike_EventBus
{
    public sealed class EnemyTurnTask : TurnPipelineTask<Task, EnemyPipeline>
    {
        public EnemyTurnTask(EnemyPipeline tPipeline) : base(tPipeline)
        {
        }
    }
}