using UniRx;

namespace Game
{
    public sealed class ProgressBarPresenter : IGameStartListener
    {
        private readonly ProgressBarView _view;
        private readonly DollarTextPair[] _pairs;

        public ProgressBarPresenter(ProgressBarView view, Player player, DollarTextPair[] pairs)
        {
            _view = view;
            _pairs = pairs;
            
            player.GetDollars.Subscribe(OnDollarsUpgrade);
        }

        private void OnDollarsUpgrade(int value)
        {
            DollarTextPair data = _pairs[^1];
            
            foreach (var stateData in _pairs)
            {
                if (value >=stateData.Value)
                {
                    data = stateData;
                    break;
                }
            }
            
            _view.SetText(data.Text);
            _view.SetBar(value);
        }

        public void OnStartGame()
        {
            _view.Show();
        }
    }
}