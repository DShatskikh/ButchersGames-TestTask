using ButchersGames;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class GlobalInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelManager _levelManager;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle().NonLazy();
        }
    }
}