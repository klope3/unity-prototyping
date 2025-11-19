using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class EnemyTemp : MonoBehaviour
    {
        [SerializeField] private ECM2.Character character;
        [SerializeField] private float chaseDistance;
        [SerializeField] private float stopDistance;
        [SerializeField] private float normalSpeed;
        private Transform playerTrans;
        private float timer;
        private bool wandering;

        private void Awake()
        {
            playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (playerTrans == null) return;

            Vector3 vecToPlayer = playerTrans.position - transform.position;
            float distToPlayer = vecToPlayer.magnitude;
            character.maxWalkSpeed = distToPlayer < stopDistance ? 0 : normalSpeed;
            if (distToPlayer < chaseDistance)
            {
                character.SetMovementDirection(vecToPlayer.normalized);
                return;
            }
            else
            {
                if (timer > 2)
                {
                    timer = 0;
                    if (wandering)
                    {
                        wandering = false;
                        character.SetMovementDirection(Vector3.zero);
                    }
                    else
                    {
                        wandering = true;
                        Vector2 rand = Random.insideUnitCircle;
                        character.SetMovementDirection(new Vector3(rand.x, 0, rand.y).normalized);
                    }
                }
            }
        }
    }
}

