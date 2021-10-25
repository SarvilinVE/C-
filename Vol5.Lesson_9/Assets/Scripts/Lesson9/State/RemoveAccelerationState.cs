namespace Asteroids.State
{
    internal sealed class RemoveAccelerationState : State
    {
        public override void Handle<T>(Context context, T TypeState)
        {
            RemoveAcceleration<T>(TypeState);
            context.State = new AddAccelerationState();
        }
    public void RemoveAcceleration<T>(T TypeState) 
        { 
            if(TypeState is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
