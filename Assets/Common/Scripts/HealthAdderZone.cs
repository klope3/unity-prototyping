using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HealthAdderZone : MonoBehaviour
{
    [SerializeField] private int amount;

    private void Awake()
    {
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthHandler health = other.GetComponent<HealthHandler>();
        if (health == null) return;

        health.AddHealth(amount, transform.position);
    }
}
