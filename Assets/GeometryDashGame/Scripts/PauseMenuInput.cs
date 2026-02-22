using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class PauseMenuInput : MonoBehaviour
    {
        [SerializeField] private PauseMenu pauseMenu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.TogglePaused();
            }
        }
    }
}
