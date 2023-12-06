using Entities;

using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class BulletTurnTask : Task
    {
        private readonly IEntity _bullet;
        private readonly EventBus _eventBus;
        private readonly Vector2Int _direction;

        public BulletTurnTask(EventBus eventBus, IEntity bullet, Vector2Int direction)
        {
            _bullet = bullet;
            _eventBus = eventBus;
            _direction = direction;
        }


        protected override void OnRun()
        {
            Debug.Log("BulletTurnTask started!");

            _eventBus.RaiseEvent(new BulletApplyDirectionEvent(_bullet, _direction));
            
            Debug.Log("BulletTurnTask finished!");
            Finish();
        }
    }
}