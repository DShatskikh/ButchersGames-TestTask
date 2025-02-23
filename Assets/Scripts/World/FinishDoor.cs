using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public class FinishDoor : MonoBehaviour
    {
        private static readonly int Open = Animator.StringToHash("Open");

        [SerializeField]
        private int _multiply = 2;

        [SerializeField]
        private int _dollars;
        
        [SerializeField]
        private bool _inEnd;
        
        [SerializeField]
        private TMP_Text _multiplyLabel;

        [SerializeField]
        private Animator _animator;

        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            
            _multiplyLabel.text = $"x{_multiply}";
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerProxy>(out var player))
            {
                if (_dollars > player.GetPlayer.GetDollars.Value && !_inEnd)
                {
                    _gameStateMachine.WinGame();
                    return;
                }
                
                _animator.SetTrigger(Open);
                player.GetPlayer.SetMultiply(_multiply);
                
                if (_inEnd) 
                    _gameStateMachine.WinGame();
            }
        }
    }
}