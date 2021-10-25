namespace Asteroids.Visitor
{
    internal abstract class CreateObjectLog
    {
        public abstract void Activate(ICreateObject createObject);
    }
}