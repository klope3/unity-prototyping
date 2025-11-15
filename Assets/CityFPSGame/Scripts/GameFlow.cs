using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverScreen;

        public void DoGameOver()
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }
}
