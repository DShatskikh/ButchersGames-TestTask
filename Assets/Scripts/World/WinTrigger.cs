using UnityEngine;
using Zenject;

namespace Game
{
    public class WinTrigger : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerProxy>(out var player))
            {
                _gameStateMachine.WinGame();
            }
        }
    }
}