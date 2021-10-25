using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    internal sealed class Ship : MonoBehaviour, IMove, IRotation, IHealth
    {
        public event Action<bool> onOverHealth;
        private IMove _moveImplementation;
        private IRotation _rotationImplementation;
        private IHealth _health;

        private State.Context _context; 
        public float Speed => _moveImplementation.Speed;
        public int Hp { get => _health.Hp; set { _health.Hp = value; } }

        public void ShipCreate(IMove moveImplementation, IRotation rotationImplementation, IHealth health)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _health = health;
            _health.onOverHealth += _health_onOverHealth;
            _context = new State.Context(new State.AddAccelerationState());
        }

        public void _health_onOverHealth(bool obj)
        {
            if (obj)
            {
                DestroyShip();
            }
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            //if (_moveImplementation is AccelerationMove accelerationMove)
            //{
            //    accelerationMove.AddAcceleration();
            //}
            _context.Request(_moveImplementation);
        }

        public void RemoveAcceleration()
        {
            //if (_moveImplementation is AccelerationMove accelerationMove)
            //{
            //    accelerationMove.RemoveAcceleration();
            //}
            _context.Request(_moveImplementation);
        }
        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
        private void DestroyShip()
        {
            Debug.Log("<Ship> Ship destroy");
        }
    }
}
