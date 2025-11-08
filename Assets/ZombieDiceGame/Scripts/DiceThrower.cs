using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    [SerializeField] private Rigidbody diceRb;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool hit = Physics.Raycast(new Ray(cameraTransform.position, cameraTransform.forward), out RaycastHit hitInfo, 1000, layerMask);
            Vector3 aimPoint = hit ? hitInfo.point : cameraTransform.position + cameraTransform.forward * 1000;
            Vector3 throwVec = aimPoint - throwPoint.position;

            diceRb.AddForce(throwVec.normalized * throwForce, ForceMode.Impulse);
            diceRb.GetComponent<Die>().Spin();
            diceRb.GetComponent<Die>().SetPhysicsActive(true);
            diceRb.GetComponent<FollowTransform>().enabled = false;
        }
    }

    [Sirenix.OdinInspector.Button]
    public void TakeDice()
    {
        diceRb.GetComponent<Die>().SetPhysicsActive(false);
        diceRb.GetComponent<FollowTransform>().enabled = true;
    }
}
