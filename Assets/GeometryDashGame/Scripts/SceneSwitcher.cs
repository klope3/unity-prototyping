using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GeometryDashGame
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        public void Switch()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ReloadScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
