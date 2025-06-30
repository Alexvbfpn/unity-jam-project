using System.Collections;
using UnityEngine;

namespace Spawners
{
    public class EdgeSpawner : MonoBehaviour
    {
        [Header("Referencias")]
        public Camera cam;                 // Si se deja vacío → Camera.main
        public Transform target;           // Centro o jugador

        [Header("Prefabs y ritmo")]
        public GameObject[] prefabs;       // Peligros que lanzar
        public float spawnInterval = 1f;   // Segundos entre spawns
        public float speed = 6f;           // Velocidad de avance

        [Tooltip("Margen fuera de la pantalla para instanciar")]
        public float offScreenMargin = 1f;

        private void Start()
        {
            if (cam == null) cam = Camera.main;
            if (target == null) target = transform;     // Hacia el centro si no hay jugador

            Invoke(nameof(StartSpawn), 1.5f);
            
            //StartCoroutine(SpawnRoutine());
        }


        protected void StartSpawn()
        {
            StartCoroutine(SpawnRoutine());
        }
        private IEnumerator SpawnRoutine()
        {
            var wait = new WaitForSeconds(spawnInterval);
            while (target != null)
            {
                SpawnOne();
                yield return wait;
            }
        }

        private void SpawnOne()
        {
            int side = Random.Range(0, 4);                 // 0-Izq, 1-Der, 2-Arriba, 3-Abajo
            Vector2 spawnPos = GetSpawnPosition(side);

            var prefab = prefabs[Random.Range(0, prefabs.Length)];
            var go = Instantiate(prefab, spawnPos, Quaternion.identity);

            // Dirección hacia el destino
            Vector2 dir = ((Vector2)target.position - spawnPos).normalized;

            // Alinea el sprite opcionalmente
            go.transform.up = dir;

            // Módulo de movimiento propio (sin físicas)
            if (!go.TryGetComponent(out MoveStraight mover))
                mover = go.AddComponent<MoveStraight>();

            mover.direction = dir;
            mover.speed = speed;
        }

        private Vector2 GetSpawnPosition(int side)
        {
            Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0));
            Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1));

            return side switch
            {
                0 => new Vector2(min.x - offScreenMargin, Random.Range(min.y, max.y)),      // Izq
                1 => new Vector2(max.x + offScreenMargin, Random.Range(min.y, max.y)),      // Der
                2 => new Vector2(Random.Range(min.x, max.x), max.y + offScreenMargin),      // Arriba
                _ => new Vector2(Random.Range(min.x, max.x), min.y - offScreenMargin),      // Abajo
            };
        }
    }
}