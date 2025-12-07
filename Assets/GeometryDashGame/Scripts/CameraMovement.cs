using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerTrans;
        [SerializeField] private float speed;

        private void Update()
        {
            Camera.main.transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, -10);
            //Vector3 pos = Camera.main.transform.position;
            //pos.x += speed * Time.deltaTime;
            //Camera.main.transform.position = pos;
        }
    }
}
