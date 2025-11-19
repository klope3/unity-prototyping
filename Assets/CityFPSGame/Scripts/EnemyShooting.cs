using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class EnemyShooting : MonoBehaviour
    {
        [SerializeField] private ProjectileGun projGun;
        [SerializeField] private float shootInterval;
        [SerializeField] private float shootDistance;
        private Transform playerTrans;
        private float timer;

        private void Awake()
        {
            playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (playerTrans == null) return;

            Vector3 adjustedPlayerPos = new Vector3(playerTrans.position.x, transform.position.y, playerTrans.position.z);
            Vector3 vecToPlayer = adjustedPlayerPos - transform.position;
            float distToPlayer = vecToPlayer.magnitude;
            transform.localEulerAngles = new Vector3();
            if (distToPlayer > shootDistance) return;
            transform.forward = vecToPlayer;
            if (timer < shootInterval) return;

            projGun.Launch();
            timer = 0;
        }
    }
}
