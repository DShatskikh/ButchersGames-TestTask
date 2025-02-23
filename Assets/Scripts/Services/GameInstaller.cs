using ButchersGames;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private StartScreenView _startScreenView;
        
        [SerializeField]
        private GameScreenView _gameScreenView;
        
        [SerializeField]
        private LoseScreenView _loseScreenView;
        
        [SerializeField]
        private WinScreenView _winScreenView;
        
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<StartScreenPresenter>().AsCached().WithArguments(_startScreenView).NonLazy();
            Container.BindInterfacesAndSelfTo<GameScreenPresenter>().AsCached().WithArguments(_gameScreenView).NonLazy();
            Container.BindInterfacesAndSelfTo<LoseScreenPresenter>().AsCached().WithArguments(_loseScreenView).NonLazy();
            Container.BindInterfacesAndSelfTo<WinScreenPresenter>().AsCached().WithArguments(_winScreenView).NonLazy();
        }
    }
}