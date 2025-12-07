using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveForce;
        [SerializeField] private float vertMoveForce;
        [SerializeField] private float targetSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpSpeed;
        [SerializeField] private float jumpSpeedOrb;
        [SerializeField] private Rigidbody2D rb;
        public bool hasOrb;
        private MovementType movementType;
        private float vertInput;

        public enum MovementType
        {
            Normal,
            Ship
        }

        private void Update()
        {
            vertInput = 0;

            if (movementType == MovementType.Normal)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Vector2 vel = rb.velocity;
                    vel.y = hasOrb ? jumpSpeedOrb : jumpSpeed;
                    rb.velocity = vel;
                }
            }

            if (movementType == MovementType.Ship)
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) vertInput++;
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) vertInput--;
            }
        }

        private void FixedUpdate()
        {
            if (rb.velocity.x < targetSpeed)
            {
                rb.AddForce(Vector2.right * moveForce);
            }

            if (movementType == MovementType.Ship)
            {
                rb.AddForce(Vector2.up * vertInput * vertMoveForce);
            }
        }

        public void SetMovementType(MovementType type)
        {
            movementType = type;
            if (movementType == MovementType.Normal) rb.gravityScale = 3;
            if (movementType == MovementType.Ship)
            {
                rb.gravityScale = 0;
                Vector2 vel = rb.velocity;
                vel.y = 0;
                rb.velocity = vel;
            }
        }
    }
}
