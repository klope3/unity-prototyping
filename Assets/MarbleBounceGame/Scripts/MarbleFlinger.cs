using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    public class MarbleFlinger : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private LayerMask marbleLayerMask;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private float force;
        [SerializeField] private float damping;
        [SerializeField] private float maxDistance;
        [SerializeField] private LineRenderer line;
        private Rigidbody grabbedRb;

        private void Update()
        {
            if (grabbedRb == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, marbleLayerMask);
                    if (hit)
                    {
                        grabbedRb = hitInfo.collider.GetComponent<Rigidbody>();
                        if (grabbedRb == null)
                        {
                            Debug.LogError("The marble ray did not find a marble rigidbody.");
                        } else
                        {
                            line.gameObject.SetActive(true);
                        }
                    }
                    return;
                }
            } else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    StopFling();
                    return;
                }

                bool cursorGround = GetCursorGroundPosition(out Vector3 cursorGroundPos);
                if (!cursorGround) return;

                Vector3 vecToCursor = cursorGroundPos - grabbedRb.position;
                vecToCursor.y = 0;
                line.SetPosition(0, grabbedRb.position);
                line.SetPosition(1, grabbedRb.position + vecToCursor);
                if (vecToCursor.magnitude > maxDistance)
                {
                    StopFling();
                    return;
                }

                Vector3 springForce = vecToCursor * force;
                Vector3 dampingForce = -1 * grabbedRb.velocity * damping;
                grabbedRb.AddForce(springForce + dampingForce);
            }
        }

        private bool GetCursorGroundPosition(out Vector3 position)
        {
            position = Vector3.zero;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, groundLayerMask);

            if (hit) position = hitInfo.point;
            return hit;
        }

        public void StopFling()
        {
            grabbedRb = null;
            line.gameObject.SetActive(false);
        }
    }
}
