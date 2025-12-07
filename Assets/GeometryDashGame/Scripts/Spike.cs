using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class Spike : MonoBehaviour
    {
        private SceneSwitcher sceneSwitcher;

        private void Awake()
        {
            sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                sceneSwitcher.ReloadScene();
            }
        }
    }
}
