using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM2;

public class FPSCharacterAdapter : MonoBehaviour
{
    [SerializeField] private Character character;

    private void Awake()
    {
        //character rotation is handled by the camera
        character.SetRotationMode(Character.RotationMode.None);
    }

    private void Update()
    {
        // Movement input, relative to character's view direction

        Vector2 inputMove = new Vector2()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical")
        };

        Vector3 movementDirection = Vector3.zero;

        movementDirection += character.GetRightVector() * inputMove.x;
        movementDirection += character.GetForwardVector() * inputMove.y;

        character.SetMovementDirection(movementDirection);

        // Crouch input

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C))
            character.Crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.C))
            character.UnCrouch();

        // Jump input

        if (Input.GetKeyDown(KeyCode.Space))
            character.Jump();
        else if (Input.GetKeyUp(KeyCode.Space))
            character.StopJumping();
    }

    public void AddControlYawInput(float value)
    {
        if (value != 0.0f)
            character.AddYawInput(value);
    }
}
