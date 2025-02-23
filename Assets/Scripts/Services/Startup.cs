using ButchersGames;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class Startup : MonoBehaviour
    {
        private LevelManager _levelManager;
        private Player _player;
        private StartScreenPresenter _startScreenPresenter;
        private DiContainer _container;

        [Inject]
        private void Construct(LevelManager levelManager, Player player, StartScreenPresenter startScreenPresenter, DiContainer container)
        {
            _levelManager = levelManager;
            _player = player;
            _startScreenPresenter = startScreenPresenter;
            _container = container;
        }
        
        private void Start()
        {
            _levelManager.Init();

            foreach (var monoBehaviour in _levelManager.GetComponentsInChildren<MonoBehaviour>())
                _container.Inject(monoBehaviour);

            _player.transform.position = _levelManager.Levels[_levelManager.CurrentLevelIndex].GetSpawnPoint.position;
            _player.transform.rotation = _levelManager.Levels[_levelManager.CurrentLevelIndex].GetSpawnPoint.rotation;
            
            _startScreenPresenter.Show();
        }
    }
}