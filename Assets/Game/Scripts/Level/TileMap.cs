using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Roguelike_EventBus
{
    public sealed class TileMap : MonoBehaviour
    {
        public Vector3 PositionOffset => _positionOffset;
        private readonly Vector3 _positionOffset = Vector2.one * 0.5f;

        [SerializeField]
        private Tilemap _tilemap;


        public bool IsWalkable(Vector2Int coordinates)
        {
            return _tilemap.HasTile((Vector3Int)coordinates);
        }

        public Vector2Int PositionToCoordinates(Vector3 position)
        {
            return (Vector2Int)_tilemap.WorldToCell(position);
        }

        public Vector3 CoordinatesToPosition(Vector2Int coordinates)
        {
            return _tilemap.CellToWorld((Vector3Int)coordinates) + PositionOffset;
        }

        public Vector3 GetRandomTilePosition()
        {
            // Получаем все позиции тайлов в пределах Tilemap.
            BoundsInt bounds = _tilemap.cellBounds;
            List<Vector3Int> allTilePositions = new List<Vector3Int>();

            foreach (var position in bounds.allPositionsWithin)
            {
                // Проверяем, есть ли тайл на данной позиции.
                if (_tilemap.HasTile(position)) 
                {
                    allTilePositions.Add(position);
                }
            }

            // Проверяем, есть ли какие-либо позиции существующих тайлов.
            if (allTilePositions.Count == 0)
            {
                Debug.LogWarning("No existing tile positions found in the Tilemap.");
                return Vector3.zero;
            }

            // Выбираем случайную позицию из списка.
            int randomIndex = Random.Range(0, allTilePositions.Count);
            Vector3Int randomTilePosition = allTilePositions[randomIndex];

            // Получаем позицию мира для выбранной позиции тайла.
            Vector3 tileWorldPosition = _tilemap.GetCellCenterWorld(randomTilePosition);

            return tileWorldPosition;
        }

    }
}
