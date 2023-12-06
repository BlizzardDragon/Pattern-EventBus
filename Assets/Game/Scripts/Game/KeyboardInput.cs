using System;
using FrameworkUnity.OOP.Interfaces.Listeners;
using UnityEngine;

namespace Roguelike_EventBus
{
    public sealed class KeyboardInput : IUpdateGameListener
    {
        public event Action<Vector2Int> MovePerformed;
        public event Action<Vector2Int> FirePerformed;


        public void OnUpdate(float _)
        {
            MoveInput();
            FireInput();
        }

        private void MoveInput()
        {
            var movement = new Vector2Int();

            if (Input.GetKey(KeyCode.W))
            {
                movement.y += 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement.y -= 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement.x += 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                movement.x -= 1;
            }

            if (movement != Vector2Int.zero)
            {
                MovePerformed?.Invoke(movement);
            }
        }

        private void FireInput()
        {
            var fire = new Vector2Int();

            if (Input.GetKey(KeyCode.UpArrow))
            {
                fire.y += 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                fire.y -= 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                fire.x += 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                fire.x -= 1;
            }

            if (fire != Vector2Int.zero)
            {
                FirePerformed?.Invoke(fire);
            }
        }
    }
}