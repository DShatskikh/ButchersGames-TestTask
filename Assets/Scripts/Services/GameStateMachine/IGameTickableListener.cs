namespace Game
{
    public interface IGameTickableListener
    {
        void Tick(float delta);
    }
        
    public interface IGameFixedTickableListener : IGameListener
    {
        void FixedTick(float delta);
    }
}