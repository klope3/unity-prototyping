using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalderTrigger : MonoBehaviour
{
    [SerializeField] private FPSCamera fpsCamera;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    [SerializeField] private GameObject restartScreenParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            restartScreenParent.SetActive(true);
            Time.timeScale = 0;
            fpsCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
