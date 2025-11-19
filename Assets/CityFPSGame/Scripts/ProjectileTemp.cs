using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTemp : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float lifespan;

    public void Launch(Vector3 vec)
    {
        rb.AddForce(vec * speed, ForceMode.Impulse);
        StartCoroutine(CO_Die());
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthHandler health = collision.collider.GetComponent<HealthHandler>();
        if (health == null) return;

        health.AddHealth(-1 * damage, transform.position);
        Destroy(gameObject);
    }

    private IEnumerator CO_Die()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
