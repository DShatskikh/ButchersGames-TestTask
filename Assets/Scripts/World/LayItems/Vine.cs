using UnityEngine;

namespace Game
{
    public class Vine : LayItem
    {
        public override void Use(Player player)
        {
            player.RemoveDollar(20);
            Handheld.Vibrate();
            Destroy(gameObject);
        }
    }
}