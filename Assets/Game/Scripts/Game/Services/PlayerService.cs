using Entities;
using FrameworkUnity.OOP.Interfaces.Listeners;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class PlayerService : MonoBehaviour
    {
        public IEntity Player => player;
        
        [SerializeField]
        private MonoEntity player;
    }
}