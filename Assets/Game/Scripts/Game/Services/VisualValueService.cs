using UnityEngine;

namespace Roguelike_EventBus
{
    public class VisualValueService : MonoBehaviour
    {
        [field: SerializeField] public float CommonAnimationDuration { get; private set; } = 0.25f;
        [field: SerializeField] public float BulletAnimationDuration { get; private set; } = 0.75f;
    }
}