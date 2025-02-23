using UnityEngine;

namespace Game
{
    public abstract class LayItem : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerProxy player))
            {
                Use(player.GetPlayer);
            }
        }

        public abstract void Use(Player player);
    }
}