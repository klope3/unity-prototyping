using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class PlayButtonAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform rt;
        [SerializeField] private float amplitude;
        [SerializeField] private float period;
        private float t;
         
        private void Update()
        {
            t += Time.deltaTime;
            float z = amplitude * Mathf.Sin(period * t);
            rt.localEulerAngles = new Vector3(0, 0, z);
        }
    }
}
