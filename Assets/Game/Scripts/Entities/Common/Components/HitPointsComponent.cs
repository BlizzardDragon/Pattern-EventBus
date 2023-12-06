using System;
using Lessons.Utils;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class HitPointsComponent
    {
        public event Action<int> ValueChanged
        {
            add => _hitPoints.ValueChanged += value;
            remove => _hitPoints.ValueChanged -= value;
        }

        public int Value
        {
            get => _hitPoints;
            set => _hitPoints.Value = Mathf.Clamp(value, 0, _maxHitPoints);
        }

        public int MaxHitPoints => _maxHitPoints;

        private readonly AtomicVariable<int> _hitPoints;
        private readonly AtomicVariable<int> _maxHitPoints;

        public HitPointsComponent(AtomicVariable<int> hitPoints, AtomicVariable<int> maxHitPoints)
        {
            _hitPoints = hitPoints;
            _maxHitPoints = maxHitPoints;
        }
    }
}