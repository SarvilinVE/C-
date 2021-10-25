using UnityEngine;
using Asteroids.Visitor;

namespace Asteroids
{
    internal sealed class InputController : IExecute, IFixExecute
    {
        private readonly Ship _ship;
        private readonly Camera _camera;
        private readonly Transform _transform;
        private readonly Weapon _weapon;
        public InputController(Ship ship, Camera camera, Transform transform, Weapon weapon)
        {
            _ship = ship;
            _camera = camera;
            _transform = transform;
            _weapon = weapon;
        }
        private void ShipMoving(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                _ship.RemoveAcceleration();
            }
        }
        private void ShipAttack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _weapon.Shooting();
                _weapon.Activate(new ConsoleDisplay());
            }
            if (Input.GetButtonDown("Fire2"))
            {
                _ship.TakeDamage(_ship.Hp);
            }
        }

        public void Execute(float deltaTime, TypeWeapon typeWeapon)
        {
            ShipAttack();
        }
        public void FixExecute(float deltaTime, TypeWeapon typeWeapon)
        {
            ShipMoving(deltaTime);
            
        }
    }
}
