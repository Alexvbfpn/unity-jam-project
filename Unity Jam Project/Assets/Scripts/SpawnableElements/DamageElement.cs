using PlayerBehaviour;
using UnityEngine;

namespace SpawnableElements
{
    public class DamageElement : ASpawnableElement
    {
        public int DamageAmount = 10; // Amount of damage to apply
        
        public override void ApplyEffect(Player player)
        {
            // Apply damage to the player
            player.Health.ApplyDamage(DamageAmount);
            
            // Log the effect application
            //Debug.Log($"Applied {damageAmount} damage to player: {player.name}");
        }
        
    }
}