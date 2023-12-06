using Entities;
using Roguelike_EventBus;
using UnityEngine;

namespace Roguelike_EventBus
{
    [RequireComponent(typeof(BarrelModel))]
    [DefaultExecutionOrder(-100)]
    public class BarrelEntity : MonoEntityBase
    {
        private void Awake()
        {
            var model = GetComponent<BarrelModel>();
            Add(new PositionComponent(model.Position.Transform));
            Add(new CoordinatesComponent(model.Position.Coordinates));
            Add(new StatsComponent(model.Stats));
            Add(new ExplosionComponent(model.Attack.Explosion));
            Add(new TransformComponent(model.transform));
            Add(new HitPointsComponent(model.Life.HitPoints, model.Life.MaxHitPoints));
            Add(new DeathComponent(model.Life.IsDead));
            Add(new DestroyComponent(gameObject));
        }
    }
}
