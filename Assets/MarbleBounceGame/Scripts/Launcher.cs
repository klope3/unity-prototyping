using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    [RequireComponent(typeof(Collider))]
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private Vector3 direction;
        private MarbleFlinger flinger;

        private void Awake()
        {
            Collider col = GetComponent<Collider>();
            col.isTrigger = true;
            flinger = FindObjectOfType<MarbleFlinger>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Marble marble = other.GetComponent<Marble>();
            if (rb == null || marble == null) return;
            rb.AddForce(direction.normalized * force, ForceMode.Impulse);
            flinger.StopFling();
        }
    }
}
