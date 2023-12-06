using Entities;
using UnityEngine;
using VContainer;

namespace Roguelike_EventBus
{
    public sealed class EntityInstaller : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity[] entities;
        private LevelMap _levelMap;


        [Inject]
        private void Construct(LevelMap levelMap)
        {
            _levelMap = levelMap;
        }

        private void Start()
        {
            foreach (var entity in entities)
            {
                InstallEntity(entity);
            }
        }

        public void InstallEntity(MonoEntity entity)
        {
            var coordinates = entity.Get<CoordinatesComponent>();
            var position = entity.Get<PositionComponent>();
            coordinates.Value = _levelMap.TileMap.PositionToCoordinates(position.Value);
            position.Value = _levelMap.TileMap.CoordinatesToPosition(coordinates.Value);

            _levelMap.EntityMap.SetEntity(coordinates.Value, entity);
        }
    }
}