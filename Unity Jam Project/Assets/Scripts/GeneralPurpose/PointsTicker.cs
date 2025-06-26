using TMPro;
using UnityEngine;

namespace GeneralPurpose
{
    public class PointsTicker : MonoBehaviour
    {
        [Header("Configuración de puntos")]
        [Tooltip("Puntos que se añaden cada vez")]
        public int pointsPerTick = 10;

        [Tooltip("Segundos entre cada suma")]
        public float tickInterval = 1f;

        [Header("Referencias UI (elige una)")]
        public TextMeshProUGUI tmpText;     // Para TextMeshPro

        private int currentPoints = 0;

        private void Start()
        {
            UpdateLabel();                                       // Muestra el valor inicial
            InvokeRepeating(nameof(AddPoints), tickInterval, tickInterval);
            // Si prefieres Coroutine, cambia esto por StartCoroutine(Ticker());
        }

        private void AddPoints()
        {
            currentPoints += pointsPerTick;
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            string label = $"Puntos: {currentPoints}";
            if (tmpText != null) tmpText.text = label;
        }

        /* --- Alternativa Coroutine (opc.) ---
        private IEnumerator Ticker()
        {
            var wait = new WaitForSeconds(tickInterval);
            while (true)
            {
                AddPoints();
                yield return wait;
            }
        }
        */   
    }
}