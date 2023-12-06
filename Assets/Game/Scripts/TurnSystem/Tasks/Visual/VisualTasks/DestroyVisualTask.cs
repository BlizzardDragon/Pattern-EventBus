using DG.Tweening;
using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class DestroyVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; } = false;

        private readonly IEntity _entity;
        private readonly LevelMap _levelMap;
        private readonly DestroyComponent _destroyComponent;
        private readonly TransformComponent _transformComponent;
        private readonly CoordinatesComponent _coordinatesComponent;
        private readonly float _duration;

        public DestroyVisualTask(IEntity entity, float duration, LevelMap levelMap)
        {
            _entity = entity;
            _levelMap = levelMap;
            _coordinatesComponent = entity.Get<CoordinatesComponent>();
            _destroyComponent = entity.Get<DestroyComponent>();
            _transformComponent = entity.Get<TransformComponent>();
            _duration = duration;
        }


        protected override void OnRun()
        {
            _transformComponent.Value.DOScale(Vector3.zero, _duration)
                .SetLink(_transformComponent.Value.gameObject)
                .OnKill(DestroyEntity);
        }

        private void DestroyEntity()
        {
            _levelMap.EntityMap.RemoveEntity(_coordinatesComponent.Value, _entity);
            _destroyComponent.Destroy();
            Finish();
        }
    }
}