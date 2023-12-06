using System;
using Entities;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Roguelike_EventBus
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int _numberDeactivatedSpawnPoints = 3;
        [SerializeField] private Transform[] _spawnPoints;
        private IEntity _player;
        private Spawner _spawner;
        private LevelMap _levelMap;


        [Inject]
        private void Construct(PlayerService playerService, Spawner spawner, LevelMap levelMap)
        {
            _player = playerService.Player;
            _spawner = spawner;
            _levelMap = levelMap;
            AlignSpawnPoints();
        }

        private void AlignSpawnPoints()
        {
            TileMap tileMap = _levelMap.TileMap;
            foreach (var spawnPoint in _spawnPoints)
            {
                spawnPoint.position = (Vector3Int)tileMap.PositionToCoordinates(spawnPoint.position) + tileMap.PositionOffset;
            }
        }

        public GameObject SpawnEnemy(string path)
        {
            Vector3 playerPositiom = _player.Get<TransformComponent>().Value.position;
            Transform[] spawnPointsToSort = SortTransformsByDistance.Sotr(playerPositiom, _spawnPoints, false);
            Array.Resize(ref spawnPointsToSort, spawnPointsToSort.Length - _numberDeactivatedSpawnPoints);

            int randomIndex = Random.Range(0, spawnPointsToSort.Length);
            Vector3 position = spawnPointsToSort[randomIndex].position;
            var newEnemy = _spawner.Spawn(path, position, Quaternion.identity);
            return newEnemy;
        }
    }
}
