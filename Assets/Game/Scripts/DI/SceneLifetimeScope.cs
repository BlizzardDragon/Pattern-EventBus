using FrameworkUnity.OOP.VContainer.Installers;
using VContainer;
using VContainer.Unity;

namespace Roguelike_EventBus
{
    public class SceneLifetimeScope : BaseGameInstallerVContainer
    {
        protected override void ConfigureSystems(IContainerBuilder builder)
        {
            ConfigureLevel(builder);
            ConfigurePlayer(builder);
            ConfigureHandlers(builder);
            ConfigureTurn(builder);
            ConfigureVisual(builder);
            ConfigureGameSystems(builder);
        }

        private void ConfigureLevel(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<TileMap>();
            builder.Register<EntityMap>(Lifetime.Singleton);
            builder.Register<LevelMap>(Lifetime.Singleton);
        }

        private void ConfigurePlayer(IContainerBuilder builder)
        {
            builder.Register<KeyboardInput>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponentInHierarchy<PlayerService>();
        }

        private void ConfigureHandlers(IContainerBuilder builder)
        {
            // EventBus.
            builder.Register<EventBus>(Lifetime.Singleton);

            // Common.
            builder.RegisterEntryPoint<AttackHandler>();
            builder.RegisterEntryPoint<DealDamageHandler>();
            builder.RegisterEntryPoint<DestroyHandler>();
            builder.RegisterEntryPoint<MoveHandler>();
            builder.RegisterEntryPoint<CollideHandler>();
            builder.RegisterEntryPoint<SpawnHandler>();
            builder.RegisterEntryPoint<ExplosionHandler>();

            // Effect.
            builder.RegisterEntryPoint<ForceDirectionHandler>();
            builder.RegisterEntryPoint<DealDamageEffectHandler>();
            builder.RegisterEntryPoint<PushEffectHandler>();
            builder.RegisterEntryPoint<BarrelExplosionEffectHandler>();

            // Player.
            builder.RegisterEntryPoint<PlayerApplyDirectionHandler>();
            builder.RegisterEntryPoint<PlayerFireHandler>();

            // Bullet.
            builder.RegisterEntryPoint<BulletApplyDirectionHandler>();
            builder.RegisterEntryPoint<BulletMoveHandler>();

            // Enemy.
            builder.RegisterEntryPoint<EnemyApplyDirectionHandler>();
            
            // Barrel.
            builder.RegisterEntryPoint<BarrelSpawnHandler>();
        }

        private void ConfigureTurn(IContainerBuilder builder)
        {
            builder.Register<TurnPipeline<Task>>(Lifetime.Singleton);
            builder.Register<EnemyPipeline>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<TurnRunner>();
            builder.RegisterEntryPoint<TurnPipelineInstaller>();
        }

        private void ConfigureVisual(IContainerBuilder builder)
        {
            builder.Register<VisualPipeline>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MoveVisualHandler>();
            builder.RegisterEntryPoint<DestroyVisualHandler>();
            builder.RegisterEntryPoint<DealDamageVisualHandler>();
            builder.RegisterEntryPoint<AttackVisualHandler>();
            builder.RegisterEntryPoint<CollideVisualHandler>();
            builder.RegisterEntryPoint<BulletHitVisualHandler>();
            builder.RegisterEntryPoint<BulletMoveVisualHandler>();
        }

        private void ConfigureGameSystems(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<Spawner>();
            builder.RegisterComponentInHierarchy<EnemySpawner>();
            builder.RegisterComponentInHierarchy<VisualValueService>();
            builder.RegisterComponentInHierarchy<HandlerValueService>();
            builder.RegisterComponentInHierarchy<EntityInstaller>();
            builder.RegisterComponentInHierarchy<LevelManager>();
        }
    }
}
