using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private bool lockCursor;

    private void Awake()
    {
        if (lockCursor) Cursor.lockState = CursorLockMode.Locked;
    }
}
