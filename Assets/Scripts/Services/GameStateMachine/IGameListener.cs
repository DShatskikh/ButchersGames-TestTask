namespace Game
{
    public interface IGameListener { }
    
    public interface IGameStartListener : IGameListener
    {
        void OnStartGame();
    }
    public interface IGameWinListener : IGameListener
    {
        void OnFinishGame();
    }

    public interface IGamePauseListener : IGameListener
    {
        void OnPauseGame();
    }

    public interface IGameResumeListener : IGameListener
    {
        void OnResumeGame();
    }
    
    public interface IGameLoseListener : IGameListener
    {
        void OnLoseGame();
    }
}