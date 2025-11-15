using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximityAttack : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float proximity;
    [SerializeField] private float cooldownSeconds;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask layerMask;
    private bool cooldown;

    private void Update()
    {
        if (cooldown) return;

        Vector3 vecToPlayer = playerTransform.position - transform.position;

        if (vecToPlayer.magnitude < proximity) StartCoroutine(CO_Attack());
    }

    private IEnumerator CO_Attack()
    {
        cooldown = true;
        bool hit = Physics.Raycast(new Ray(transform.position, playerTransform.position - transform.position), out RaycastHit hitInfo, 100, layerMask);
        if (hit)
        {
            hitInfo.collider.GetComponent<HealthHandler>().AddHealth(-1 * damage, transform.position);
        }

        yield return new WaitForSeconds(cooldownSeconds);
        cooldown = false;
    }
}
