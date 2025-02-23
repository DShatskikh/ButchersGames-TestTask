using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerProxy : MonoBehaviour
    {
        private Player _player;
        
        public Player GetPlayer => _player;
        
        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }
    }
}