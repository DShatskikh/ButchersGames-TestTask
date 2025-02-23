using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private ProgressBarView _progressBarView;
        
        [SerializeField]
        private DollarTextPair[] _dollarTextPairs;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProgressBarPresenter>().AsCached().WithArguments(_progressBarView, _dollarTextPairs).NonLazy();
        }
    }
}