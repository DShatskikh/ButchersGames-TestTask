using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class LoseScreenPresenter : IGameLoseListener
    {
        private readonly LoseScreenView _view;

        public LoseScreenPresenter(LoseScreenView view)
        {
            _view = view;
            
            view.GetResetButton.onClick.AddListener(OnResetButtonClicked);
        }

        public void OnLoseGame()
        {
            _view.Show();
        }

        private void OnResetButtonClicked()
        {
            SceneManager.LoadScene(0);
        }
    }
}