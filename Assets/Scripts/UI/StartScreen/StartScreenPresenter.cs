using DG.Tweening;
using UnityEngine.EventSystems;

namespace Game
{
    public sealed class StartScreenPresenter : IGameStartListener
    {
        private readonly StartScreenView _view;
        private readonly GameStateMachine _gameStateMachine;
        private readonly Sequence _sequence;

        public StartScreenPresenter(StartScreenView view, GameStateMachine gameStateMachine)
        {
            _view = view;
            _gameStateMachine = gameStateMachine;
            
            view.EventTrigger.triggers[(int)EventTriggerType.PointerEnter]
                .callback.AddListener(evt => OnStartGameButtonClicked());

            view.Hand.position = view.Hand.position.SetX(view.HandPoint2.position.x);
            
            _sequence = DOTween.Sequence();
            _sequence
                .Append(view.Hand.DOLocalMoveX(view.HandPoint1.localPosition.x, 0.5f).SetEase(Ease.OutSine))
                .Append(view.Hand.DOLocalMoveX(view.HandPoint2.localPosition.x, 0.5f).SetEase(Ease.OutSine))
                .SetLoops(-1, LoopType.Restart);
        }

        private void OnStartGameButtonClicked()
        {
            _gameStateMachine.StartGame();
        }

        public void OnStartGame()
        {
            _sequence?.Kill();
            _view.Hide();
        }

        public void Show()
        {
            _view.Show();
        }
    }
}