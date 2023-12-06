using VContainer;
using VContainer.Unity;

namespace Roguelike_EventBus
{
    public class TurnPipelineInstaller : IInitializable
    {
        private TurnPipeline<Task> _turnPipeline;
        private IObjectResolver _objectResolver;


        public TurnPipelineInstaller(TurnPipeline<Task> turnPipeline, IObjectResolver objectResolver)
        {
            _turnPipeline = turnPipeline;
            _objectResolver = objectResolver;
        }

        public void Initialize()
        {
            _turnPipeline.AddTask(new StartTurnTask());

            _turnPipeline.AddTask(_objectResolver.CreateInstance<EnemySpawnTurnTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<BarrelSpawnTurnTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<PlayerTurnTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<EnemyTurnTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<VisualTurnTask>());

            _turnPipeline.AddTask(new FinishTurnTask());
        }
    }
}