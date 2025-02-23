using UnityEngine;

namespace Game
{
    public class Dollar : LayItem
    {
        public override void Use(Player player)
        {
            player.AddDollar(1);
            Handheld.Vibrate();
            Destroy(gameObject);
        }
    }
}