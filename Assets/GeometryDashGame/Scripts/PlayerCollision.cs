using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class PlayerCollision : MonoBehaviour
    {
        private SceneSwitcher sceneSwitcher;

        private void Awake()
        {
            sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ContactPoint2D contact = collision.GetContact(0);
            float normalLeftness = Vector2.Dot(Vector2.left, contact.normal);
            float normalDownness = Vector2.Dot(Vector2.down, contact.normal);

            bool die = normalLeftness > 0.999f || normalDownness > 0.999f;
            if (die) sceneSwitcher.ReloadScene();
        }
    }
}
