using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class TransitionRotateTrigger : MonoBehaviour
    {
        [SerializeField]
        private Transform _targetPoint;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerProxy>(out var player))
            {
                var rotateComponent = player.GetPlayer.AddComponent<RotateComponent>();
                rotateComponent.Init(_targetPoint.eulerAngles);
            }
        }
    }
}