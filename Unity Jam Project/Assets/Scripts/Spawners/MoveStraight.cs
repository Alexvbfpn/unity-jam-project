using UnityEngine;

namespace Spawners
{
    public class MoveStraight : MonoBehaviour
    {
        [HideInInspector] public Vector2 direction = Vector2.right;  // La define el spawner
        [HideInInspector] public float speed = 6f;

        [Tooltip("Segundos antes de que el objeto se destruya solo")]
        public float lifeTime = 5f;

        private void Start()
        {
            if (lifeTime > 0)
                Destroy(gameObject, lifeTime);
        }
        
        private void Update()
        {
            transform.position += (Vector3)(direction * (speed * Time.deltaTime));
        }
    }
}