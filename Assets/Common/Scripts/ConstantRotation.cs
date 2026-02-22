using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour 
{
    [SerializeField] private Vector3 speed;

    private void Update()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.x += speed.x * Time.deltaTime;
        euler.y += speed.y * Time.deltaTime;
        euler.z += speed.z * Time.deltaTime;
        transform.localEulerAngles = euler;
    }
}
