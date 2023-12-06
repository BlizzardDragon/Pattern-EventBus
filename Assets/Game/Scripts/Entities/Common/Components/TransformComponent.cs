using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class TransformComponent
    {
        public Transform Value {get;}
        
        public TransformComponent(Transform transform)
        {
            Value = transform;
        }
    }
}