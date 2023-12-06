using Entities;
using UnityEngine;
namespace Roguelike_EventBus
{
    public class BarrelSpawnHandler : BaseHandler<BarrelSpawnEvent>
    {
        private readonly LevelMap _levelMap;
        private readonly EntityInstaller _entityInstaller;
        private readonly Spawner _spawner;
        private readonly HandlerValueService _handlerValue;

        public BarrelSpawnHandler(
            LevelMap levelMap,
            EntityInstaller entityInstaller,
            Spawner spawner,
            HandlerValueService handlerValue,
            EventBus eventBus) : base(eventBus)
        {
            _levelMap = levelMap;
            _entityInstaller = entityInstaller;
            _spawner = spawner;
            _handlerValue = handlerValue;
        }


        protected override void HandleEvent(BarrelSpawnEvent evt)
        {
            Vector3 spawnPosition = _levelMap.TileMap.GetRandomTilePosition();
            GameObject newBarrel = _spawner.Spawn(_handlerValue.PathBarrel1, spawnPosition, Quaternion.identity);
            MonoEntity monoEntity = newBarrel.GetComponent<MonoEntity>();
            _entityInstaller.InstallEntity(monoEntity);

            monoEntity.Get<DeathComponent>().IsDeadChanged += _ =>
                EventBus.RaiseEvent(new ExplosionEvent(monoEntity));
        }
    }
}