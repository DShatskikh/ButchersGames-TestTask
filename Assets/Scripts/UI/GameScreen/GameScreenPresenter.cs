
using ButchersGames;
using UniRx;

namespace Game
{
    public sealed class GameScreenPresenter : IGameStartListener
    {
        private readonly GameScreenView _view;

        public GameScreenPresenter(GameScreenView view, Player player, LevelManager levelManager)
        {
            _view = view;

            view.SetLevel($"Уровень {levelManager.CurrentLevelIndex + 1}");
            player.GetDollars.Subscribe(OnChangeDollars);
        }

        public void OnStartGame() => 
            _view.Show();

        private void OnChangeDollars(int dollars) => 
            _view.SetDollars($"{dollars}");
    }
}