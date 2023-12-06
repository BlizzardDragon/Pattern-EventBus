using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class EntityMap
    {
        public Dictionary<Vector2Int, List<IEntity>> Entities => _entities;
        private readonly Dictionary<Vector2Int, List<IEntity>> _entities = new();


        public bool HasEntity(Vector2Int coordinates)
        {
            return _entities.ContainsKey(coordinates) && _entities[coordinates].Count > 0;
        }

        public List<IEntity> GetEntities(Vector2Int coordinates)
        {
            return _entities.ContainsKey(coordinates) ? _entities[coordinates] : new List<IEntity>();
        }

        public void RemoveEntity(Vector2Int coordinates, IEntity entity)
        {
            if (_entities.ContainsKey(coordinates))
            {
                _entities[coordinates].Remove(entity);
            }
        }

        public void SetEntity(Vector2Int coordinates, IEntity entity)
        {
            if (!_entities.ContainsKey(coordinates))
            {
                _entities[coordinates] = new List<IEntity> { entity };
            }
            else
            {
                _entities[coordinates].Add(entity);
            }
        }
    }
}