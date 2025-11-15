using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class EnemyTemp : MonoBehaviour
    {
        [SerializeField] private ECM2.Character character;
        [SerializeField] private Transform playerTrans;
        [SerializeField] private float chaseDistance;
        private float timer;
        private bool wandering;

        private void Update()
        {
            timer += Time.deltaTime;

            Vector3 vecToPlayer = playerTrans.position - transform.position;
            float distToPlayer = vecToPlayer.magnitude;
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

