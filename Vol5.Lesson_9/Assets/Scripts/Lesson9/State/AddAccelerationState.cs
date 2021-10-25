namespace Asteroids.State
{
    internal sealed class AddAccelerationState : State
    {
        public override void Handle<T>(Context context, T TypeState)
        {
            AddAcceleration<T>(TypeState);
            context.State = new RemoveAccelerationState();
        }
        public void AddAcceleration<T>(T TypeState)
        {
            if(TypeState is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
    }
}
