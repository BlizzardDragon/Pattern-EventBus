namespace Roguelike_EventBus
{
    public sealed class LevelMap
    {
        public EntityMap EntityMap { get; }
        
        public TileMap TileMap { get; }

        public LevelMap(EntityMap entities, TileMap tiles)
        {
            EntityMap = entities;
            TileMap = tiles;
        }
    }
}