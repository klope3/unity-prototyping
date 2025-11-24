using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CityFPSGame
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject victoryScreen;
        [SerializeField] private FPSCamera fpsCamera;

        public void DoGameOver()
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            fpsCamera.enabled = false;
        }

        public void Restart()
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1;
        }

        public void DoVictory()
        {
            Time.timeScale = 0;
            victoryScreen.SetActive(true);
            fpsCamera.enabled = false;
        }
    }
}
