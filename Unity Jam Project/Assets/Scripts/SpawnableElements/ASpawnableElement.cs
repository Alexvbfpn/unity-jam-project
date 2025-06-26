using PlayerBehaviour;
using UnityEngine;

namespace SpawnableElements
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class ASpawnableElement : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                Player p = other.GetComponent<Player>();
                // Aquí llamas a tu sistema de salud / efectos
                
                ApplyEffect(p);    
                
                // Opcional: destruir el hazard tras impactar
                Destroy(gameObject);
            }
        }
        
        public virtual void ApplyEffect(Player player)
        {
            // Override this method in derived classes to apply specific effects
            // For example, you could increase health, apply damage, etc.
            Debug.Log("Effect applied to player: " + player.name);
        }
    }
}