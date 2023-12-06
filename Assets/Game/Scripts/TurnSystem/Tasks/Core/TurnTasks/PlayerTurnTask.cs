using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class PlayerTurnTask : Task
    {
        private readonly KeyboardInput _input;
        private readonly IEntity _player;
        private readonly EventBus _eventBus;

        public PlayerTurnTask(KeyboardInput input, EventBus eventBus, PlayerService playerService)
        {
            _input = input;
            _player = playerService.Player;
            _eventBus = eventBus;
        }


        protected override void OnRun()
        {
            _input.MovePerformed += OnMovePerformed;
            _input.FirePerformed += OnFirePerformed;
        }

        private void OnMovePerformed(Vector2Int direction)
        {
            Unsubscribe();
            _eventBus.RaiseEvent(new PlayerApplyDirectionEvent(_player, direction));
            Finish();
        }

        private void OnFirePerformed(Vector2Int direction)
        {
            Unsubscribe();
            _eventBus.RaiseEvent(new PlayerFireEvent(_player, direction));
            Finish();
        }

        private void Unsubscribe()
        {
            _input.MovePerformed -= OnMovePerformed;
            _input.FirePerformed -= OnFirePerformed;
        }
    }
}