using System;
using PlayerBehaviour;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GeneralPurpose
{
    public class ReloadScene : MonoBehaviour
    {
        public Canvas canvas;
        
        public void Awake()
        {
            canvas = GetComponent<Canvas>();
            canvas.enabled = false;
            
            
        }

        public void Start()
        {
            FindObjectOfType<Player>().Health.OnPlayerDied.AddListener(() => FinishGame());
        }

        protected void FinishGame()
        {
            canvas.enabled = true;
            FindObjectOfType<TimerDisplay>().isRunning = false;
            FindObjectOfType<PointsTicker>().isRunning = false;
        }

        /// <summary>
        /// Reloads the current scene.
        /// </summary>
        public void ReloadCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        /// <summary>
        /// Reloads the scene with the specified name.
        /// </summary>
        /// <param name="sceneName">The name of the scene to reload.</param>
        public void ReloadSceneByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}