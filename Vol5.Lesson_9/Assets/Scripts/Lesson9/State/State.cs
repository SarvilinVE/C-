using System.Collections;
using System.Collections.Generic;
namespace Asteroids.State
{
    internal abstract class State
    {
        public abstract void Handle<T>(Context context, T TypeState);
    }
}
