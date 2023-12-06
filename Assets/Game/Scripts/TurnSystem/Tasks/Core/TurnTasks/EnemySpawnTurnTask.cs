

namespace Roguelike_EventBus
{
    public sealed class EnemySpawnTurnTask : Task
    {
        private readonly EventBus _eventBus;
        private int _turnCounter;
        private const int SPAWN_INTERVAL = 2;

        public EnemySpawnTurnTask(EventBus eventBus)
        {
            _eventBus = eventBus;
        }


        protected override void OnRun()
        {
            _turnCounter++;

            if (_turnCounter == 1)
            {
                CreateSpawnEvent();
            }

            if (_turnCounter == SPAWN_INTERVAL + 1)
            {
                _turnCounter = 0;
            }

            Finish();
        }

        private void CreateSpawnEvent()
        {
            _eventBus.RaiseEvent(new SpawnEvent(SpawnTypes.Enemy));
        }
    }
}