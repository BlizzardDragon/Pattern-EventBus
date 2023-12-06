using Entities;
using UnityEngine;
using VContainer;

namespace Roguelike_EventBus
{
    public sealed class SpawnHandler : BaseHandler<SpawnEvent>
    {
        private readonly EntityInstaller _entityInstaller;
        private readonly Spawner _spawner;
        private readonly EnemySpawner _enemySpawner;
        private readonly TurnPipeline<Task> _turnPipeline;
        private readonly EnemyPipeline _enemyPipeline;
        private IObjectResolver _objectResolver;

        private const string PATH_BULLET = "Bullet";
        private const string PATH_ENEMY = "Enemy";

        public SpawnHandler(
            EntityInstaller entityInstaller,
            Spawner spawner,
            EnemySpawner enemySpawner,
            TurnPipeline<Task> turnPipeline,
            EnemyPipeline enemyPipeline,
            IObjectResolver objectResolver,
            EventBus eventBus) : base(eventBus)
        {
            _entityInstaller = entityInstaller;
            _spawner = spawner;
            _enemySpawner = enemySpawner;
            _turnPipeline = turnPipeline;
            _enemyPipeline = enemyPipeline;
            _objectResolver = objectResolver;
        }


        protected override void HandleEvent(SpawnEvent evt)
        {
            if (evt.Type == SpawnTypes.Enemy)
            {
                // Спавн Enemy.
                GameObject newEnemy = _enemySpawner.SpawnEnemy(PATH_ENEMY);
                var enemyEntity = newEnemy.GetComponent<MonoEntity>();

                // Создание EnemyTask.
                var enemyTurnTask = _objectResolver.CreateInstance<EnemyTask>();
                _entityInstaller.InstallEntity(enemyEntity);
                enemyTurnTask.InstallEntity(enemyEntity);

                // Добавление EnemyTask в EnemyPipeline.
                _enemyPipeline.AddTask(enemyTurnTask);

                // Подписка на удаление EnemyTask из EnemyPipeline.
                enemyEntity.Get<DeathComponent>().IsDeadChanged += isDead =>
                {
                    _enemyPipeline.RemoveTask(enemyTurnTask);
                };

                return;
            }

            #region Спавн и инициализация объекта
            SpawnTypes type = evt.Type;
            string prefabPath = "";

            if (type == SpawnTypes.Bullet)
            {
                prefabPath = PATH_BULLET;
            }

            Vector2Int direction = evt.Direction;
            Quaternion rotatin;

            if (direction != Vector2Int.zero)
            {
                rotatin = Quaternion.LookRotation(Vector3.forward, (Vector3Int)direction);
            }
            else
            {
                rotatin = Quaternion.identity;
            }

            var position = evt.Entity.Get<PositionComponent>().Value;
            var newBullet = _spawner.Spawn(prefabPath, position, rotatin);
            var monoEntity = newBullet.GetComponent<MonoEntity>();
            _entityInstaller.InstallEntity(monoEntity);
            #endregion

            #region Добавление и удаление TurnTask в/из TurnPipeline
            if (type == SpawnTypes.Bullet)
            {
                Task turnTask = null;
                turnTask = new BulletTurnTask(EventBus, monoEntity, evt.Direction);

                _turnPipeline.InsertTask(turnTask);
                monoEntity.Get<DeathComponent>().IsDeadChanged += isDead =>
                {
                    _turnPipeline.Finished += () => _turnPipeline.RemoveTask(turnTask);
                };
            }
            #endregion
        }
    }
}