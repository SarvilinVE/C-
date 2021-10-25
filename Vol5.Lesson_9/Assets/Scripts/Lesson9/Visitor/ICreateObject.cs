using System.Collections;
using System.Collections.Generic;
namespace Asteroids.Visitor
{
    internal interface ICreateObject
    {
        void Visitor(Weapon weapon);
    }
}