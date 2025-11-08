using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class Die : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float randTorqueAmount;
    [SerializeField] private float angularVelocityThreshold = 0.01f;
    [SerializeField] private float minRollTime = 0.1f;
    [SerializeField] private float angularVelocityThresholdTime = 0.1f;
    [SerializeField] private TextMeshProUGUI text;
    private bool prevFrameRolling;
    private int resolvedFace;
    private float timeBelowAngularVelocityThreshold;

    private void Awake()
    {
        resolvedFace = 0;
    }

    private void Update()
    {
        text.text = "rolling";
        if (rb.angularVelocity.magnitude > angularVelocityThreshold)
        {
            resolvedFace = 0;
            timeBelowAngularVelocityThreshold = 0;
            prevFrameRolling = true;
            return;
        }
        timeBelowAngularVelocityThreshold += Time.deltaTime;
        if (timeBelowAngularVelocityThreshold < angularVelocityThresholdTime)
        {
            return;
        }
        text.text = "rest";
        if (!prevFrameRolling)
        {
            return;
        }
        prevFrameRolling = false;
        //if (resolvedFace > 0)
        //{
        //    return;
        //}

        float dot1 = Vector3.Dot(transform.up, Vector3.up);
        float dot2 = Vector3.Dot(transform.right, Vector3.up);
        float dot3 = Vector3.Dot(transform.forward, Vector3.up);
        float dot4 = Vector3.Dot(-1 * transform.forward, Vector3.up);
        float dot5 = Vector3.Dot(-1 * transform.right, Vector3.up);
        float dot6 = Vector3.Dot(-1 * transform.up, Vector3.up);
        
        if (dot1 > 0.99f)
        {
            resolvedFace = 1;
        }
        if (dot2 > 0.99f)
        {
            resolvedFace = 2;
        }
        if (dot3 > 0.99f)
        {
            resolvedFace = 3;
        }
        if (dot4 > 0.99f)
        {
            resolvedFace = 4;
        }
        if (dot5 > 0.99f)
        {
            resolvedFace = 5;
        }
        if (dot6 > 0.99f)
        {
            resolvedFace = 6;
        }
        Debug.Log(resolvedFace);
    }

    [Button]
    public void Spin()
    {
        Vector3 randomTorque = new Vector3(
            Random.Range(-1 * randTorqueAmount, randTorqueAmount),
            Random.Range(-1 * randTorqueAmount, randTorqueAmount),
            Random.Range(-1 * randTorqueAmount, randTorqueAmount)
        );

        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    [Button]
    public void ResetDie()
    {
        transform.position = new Vector3(0, 3, 0);
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        resolvedFace = 0;
    }

    [Button]
    public void Roll()
    {
        rb.useGravity = true;
        Spin();
    }
}
