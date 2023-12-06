

namespace Roguelike_EventBus
{
    public sealed class BarrelSpawnTurnTask : Task
    {
        private readonly EventBus _eventBus;
        private int _turnCounter;
        private const int SPAWN_INTERVAL = 10;

        public BarrelSpawnTurnTask(EventBus eventBus)
        {
            _eventBus = eventBus;
        }


        protected override void OnRun()
        {
            _turnCounter++;

            if (_turnCounter >= SPAWN_INTERVAL + 1)
            {
                CreateSpawnEvent();
                _turnCounter = 0;
            }

            Finish();
        }

        private void CreateSpawnEvent()
        {
            _eventBus.RaiseEvent(new BarrelSpawnEvent());
        }
    }
}