using ButchersGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class WinScreenPresenter : IGameWinListener
    {
        private readonly WinScreenView _view;
        private readonly LevelManager _levelManager;

        public WinScreenPresenter(WinScreenView view, LevelManager levelManager)
        {
            _view = view;
            _levelManager = levelManager;
            
            view.GetNextButton.onClick.AddListener(OnNextButtonClicked);
            view.GetX2Button.onClick.AddListener(OnX2ButtonClicked);
        }

        public void OnFinishGame()
        {
            _view.Show();
            _view.SetLevelText($"Уровень {_levelManager.CurrentLevelIndex + 1}\nЗавершено");
        }

        private void OnX2ButtonClicked()
        {
            Debug.Log("x2");
            SceneManager.LoadScene(0);
        }

        private void OnNextButtonClicked()
        {
            Debug.Log("next");
            SceneManager.LoadScene(0);
        }
    }
}