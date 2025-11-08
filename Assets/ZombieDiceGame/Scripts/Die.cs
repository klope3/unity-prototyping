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
    [SerializeField] private DieFaceSO face1;
    [SerializeField] private DieFaceSO face2;
    [SerializeField] private DieFaceSO face3;
    [SerializeField] private DieFaceSO face4;
    [SerializeField] private DieFaceSO face5;
    [SerializeField] private DieFaceSO face6;
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

        float dot1 = Vector3.Dot(transform.up, Vector3.up);
        float dot2 = Vector3.Dot(transform.right, Vector3.up);
        float dot3 = Vector3.Dot(transform.forward, Vector3.up);
        float dot4 = Vector3.Dot(-1 * transform.forward, Vector3.up);
        float dot5 = Vector3.Dot(-1 * transform.right, Vector3.up);
        float dot6 = Vector3.Dot(-1 * transform.up, Vector3.up);
        
        if (dot1 > 0.99f)
        {
            resolvedFace = 1;
            face1.Execute();
        }
        if (dot2 > 0.99f)
        {
            resolvedFace = 2;
            face2.Execute();
        }
        if (dot3 > 0.99f)
        {
            resolvedFace = 3;
            face3.Execute();
        }
        if (dot4 > 0.99f)
        {
            resolvedFace = 4;
            face4.Execute();
        }
        if (dot5 > 0.99f)
        {
            resolvedFace = 5;
            face5.Execute();
        }
        if (dot6 > 0.99f)
        {
            resolvedFace = 6;
            face6.Execute();
        }
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
