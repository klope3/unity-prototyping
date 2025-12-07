using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class JumpPad : MonoBehaviour
    {
        [SerializeField] private float force; 

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                Vector2 vel = rb.velocity;
                vel.y = force;
                rb.velocity = vel;
            }
        }
    }
}
