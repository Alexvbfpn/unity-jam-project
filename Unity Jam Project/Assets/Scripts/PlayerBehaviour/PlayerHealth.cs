using UnityEngine;
using UnityEngine.Events;

namespace PlayerBehaviour
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Health")]
        /// the player's maximum health
        public int MaxHealth = 100;
        /// the player's current health
        public int CurrentHealth;

        [Header("Events")]
        public UnityEvent OnPlayerDamaged;
        public UnityEvent OnPlayerDied;

        protected virtual void Awake()
        {
            CurrentHealth = MaxHealth;
        }

        /// <summary>
        /// Applies damage to the player
        /// </summary>
        /// <param name="damage">The amount of damage to apply</param>
        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            OnPlayerDamaged?.Invoke();

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Handles the player's death
        /// </summary>
        protected virtual void Die()
        {
            OnPlayerDied?.Invoke();
            GetComponent<Player>().isAlive = false;
            Destroy(gameObject, 1);
            // Additional death logic can be added here
            //Debug.Log("Player has died.");
        }
    }
}