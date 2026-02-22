using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM2;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] private FPSCharacterAdapter characterAdapter;
    [SerializeField] private Transform cameraParent;
    [SerializeField] private bool invertLook = true;
    [SerializeField, Tooltip("Mouse look sensitivity")]
    private Vector2 mouseSensitivity = new Vector2(1.0f, 1.0f);
    private float cameraPitch;

    [SerializeField, Tooltip("How far in degrees can you move the camera down.")]
    public float minPitch = -80.0f;
    [SerializeField, Tooltip("How far in degrees can you move the camera up.")]
    public float maxPitch = 80.0f;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Vector2 lookInput = new Vector2
        {
            x = Input.GetAxisRaw("Mouse X"),
            y = Input.GetAxisRaw("Mouse Y")
        };

        lookInput *= mouseSensitivity;

        characterAdapter.AddControlYawInput(lookInput.x);
        AddControlPitchInput(invertLook ? -lookInput.y : lookInput.y);
    }

    private void LateUpdate()
    {
        cameraParent.transform.localRotation = Quaternion.Euler(cameraPitch, 0.0f, 0.0f);
    }

    public void AddControlPitchInput(float value, float minPitch = -80.0f, float maxPitch = 80.0f)
    {
        if (value != 0.0f)
            cameraPitch = MathLib.ClampAngle(cameraPitch + value, minPitch, maxPitch);
    }
}
