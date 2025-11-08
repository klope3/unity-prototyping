using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM2;

public class ThirdPersonMovementSimple : MonoBehaviour
{
    [SerializeField] private Character character;

    private void Update()
    {
        int zInput = 0;
        int xInput = 0;

        if (Input.GetKey(KeyCode.W)) zInput++;
        if (Input.GetKey(KeyCode.S)) zInput--;
        if (Input.GetKey(KeyCode.A)) xInput--;
        if (Input.GetKey(KeyCode.D)) xInput++;

        if (Input.GetKeyDown(KeyCode.Space) && character.IsOnGround()) character.Jump();
        if (Input.GetKeyUp(KeyCode.Space)) character.StopJumping();

        Vector3 initialVec = new Vector3(xInput, 0, zInput).normalized;
        Vector3 moveVec = initialVec.relativeTo(character.cameraTransform);

        character.SetMovementDirection(moveVec);
    }
}
