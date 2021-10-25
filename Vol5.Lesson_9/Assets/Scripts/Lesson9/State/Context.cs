using UnityEngine;
namespace Asteroids.State
{
    internal sealed class Context
    {
        private State _state;
        public Context(State state)
        {
            _state = state;
        }
        public State State
        {
            set
            {
                _state = value;
                Debug.Log($"State: {_state.GetType().Name}");
            }
        }
        public void Request<T>(T TypeState)
        {
            _state.Handle<T>(this,TypeState);
        }
    }
}
