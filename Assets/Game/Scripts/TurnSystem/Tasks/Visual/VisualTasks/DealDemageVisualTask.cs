using DG.Tweening;
using Entities;
using Roguelike_EventBus;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class DealDemageVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; } = true;

        private readonly TransformComponent _transform;
        private readonly float _dutation;

        public DealDemageVisualTask(IEntity entity, float dutation)
        {
            _transform = entity.Get<TransformComponent>();
            _dutation = dutation;
        }


        protected override void OnRun()
        {
            _transform.Value.DOPunchScale(Vector3.one * 1.2f, _dutation, 5)
                .SetLink(_transform.Value.gameObject)
                .OnKill(Finish);
        }
    }
}