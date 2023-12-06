using System;
using Lessons.Utils;
using UnityEngine;

namespace Roguelike_EventBus.Common.Model
{
    [Serializable]
    public sealed class Position
    {
        public Transform Transform;
        
        public AtomicVariable<Vector2Int> Coordinates;   
    }
}