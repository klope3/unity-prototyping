using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    public class Bouncer : MonoBehaviour
    {
        [SerializeField] private float force;

        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null) rb.AddForce(transform.forward * force, ForceMode.Impulse);

            Marble marble = collision.collider.GetComponent<Marble>();
            if (marble != null) marble.DoBounce();
        }
    }
}
