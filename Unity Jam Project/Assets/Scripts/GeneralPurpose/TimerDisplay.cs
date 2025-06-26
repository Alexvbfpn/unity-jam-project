using TMPro;
using UnityEngine;

namespace GeneralPurpose
{
    public class TimerDisplay : MonoBehaviour
    {
        [Header("Configuración")]
        public bool countUp = true;
        public float startTime = 60f;

        [Header("Referencias UI")]
        public TextMeshProUGUI tmpText;

        private float timer;
        private bool isRunning = true;

        private void Start()
        {
            timer = countUp ? 0f : startTime;
            UpdateLabel();
        }

        private void Update()
        {
            if (!isRunning) return;

            timer += (countUp ? 1 : -1) * Time.deltaTime;

            if (!countUp && timer <= 0f)
            {
                timer = 0f;
                isRunning = false;
            }

            UpdateLabel();
        }

        private void UpdateLabel()
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            int tenths  = Mathf.FloorToInt((timer * 10f) % 10f);  // décima de segundo

            string label = $"Tiempo: {minutes:00}:{seconds:00}.{tenths}";
            
            if (tmpText) tmpText.text = label;
        }

        public void StopTimer() => isRunning = false;
        public void StartTimer() => isRunning = true;
    }
}