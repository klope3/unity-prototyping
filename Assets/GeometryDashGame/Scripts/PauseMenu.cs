using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private bool paused;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePaused();
            }
        }

        public void TogglePaused()
        {
            paused = !paused;
            pauseMenu.SetActive(paused);
            Time.timeScale = paused ? 0 : 1;
            AudioListener.pause = paused;
        }
    }
}
