using UnityEngine;
namespace Asteroids.Visitor
{
    internal sealed class ConsoleDisplay : ICreateObject
    {
        public void Visitor(Weapon weapon)
        {
            Debug.Log($"{nameof(weapon)}");
        }
    }
}