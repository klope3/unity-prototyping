using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class Orb : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();
            if (movement != null) movement.hasOrb = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();
            if (movement != null) movement.hasOrb = false;
        }
    }
}
