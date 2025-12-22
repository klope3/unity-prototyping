using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    public class MarbleNudger : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private float force;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layerMask;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, layerMask);

                if (!hit) return;
                Collider[] colliders = Physics.OverlapSphere(hitInfo.point, radius);
                foreach (Collider c in colliders)
                {
                    Rigidbody rb = c.GetComponent<Rigidbody>();
                    if (rb == null) continue;

                    Vector3 vecToRb = rb.transform.position - hitInfo.point;
                    vecToRb.y = 0;
                    rb.AddForce(vecToRb.normalized * force, ForceMode.Impulse);
                }
            }
        }
    }
}
