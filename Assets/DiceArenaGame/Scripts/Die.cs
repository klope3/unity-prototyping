using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace DiceArenaGame
{
    public class Die : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float spinForce;
        [SerializeField] private float spinTime;
        private bool rolling;

        [Button]
        public void Roll()
        {
            if (rolling) return;
            StartCoroutine(CO_Roll());
        }

        private IEnumerator CO_Roll()
        {
            rolling = true;

            rb.AddTorque(Vector3.one * spinForce, ForceMode.Impulse);
            yield return new WaitForSeconds(spinTime);
            int rand = Random.Range(1, 6);
            Debug.Log(rand);
            rb.angularVelocity = Vector3.zero;
            SetFace(rand);

            rolling = false;
        }

        public void SetFace(int face)
        {
            if (face == 1) rb.transform.eulerAngles = new Vector3(0, 45, 0);
            if (face == 2) rb.transform.eulerAngles = new Vector3(0, 45, 90);
            if (face == 3) rb.transform.eulerAngles = new Vector3(-90, 45, 0);
            if (face == 4) rb.transform.eulerAngles = new Vector3(90, 45, 0);
            if (face == 5) rb.transform.eulerAngles = new Vector3(0, -45, -90);
            if (face == 6) rb.transform.eulerAngles = new Vector3(180, 45, 0);
        }
    }
}
