using DG.Tweening;
using Entities;
using Roguelike_EventBus;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class MoveVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; }

        private readonly TransformComponent _transformComponent;
        private readonly Vector3 _targetPosition;
        private readonly float _duration;
        private readonly Ease _ease;

        public MoveVisualTask(
            IEntity entity,
            Vector3 targetPosition,
            float duration,
            bool sticky = false,
            Ease ease = default)
        {
            _transformComponent = entity.Get<TransformComponent>();
            _targetPosition = targetPosition;
            _duration = duration;
            Sticky = sticky;
            _ease = ease;
        }


        protected override void OnRun()
        {
            _transformComponent.Value.DOMove(_targetPosition, _duration)
                .SetLink(_transformComponent.Value.gameObject)
                .SetEase(_ease)
                .OnKill(Finish);
        }
    }
}