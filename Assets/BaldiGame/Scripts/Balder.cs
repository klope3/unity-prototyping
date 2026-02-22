using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaldiGame
{
    public class Balder : MonoBehaviour
    {
        [SerializeField] private ECM2.Character character;
        [SerializeField] private Transform playerTrans;
        [SerializeField] private float chaseSpeed1;
        [SerializeField] private float chaseSpeed2;
        private int chaseState;

        private void Update()
        {
            if (chaseState > 0)
            {
                Vector3 vecToPlayer = playerTrans.position - transform.position;
                character.SetMovementDirection(vecToPlayer);
            }
        }

        public void IncrementChaseState()
        {
            chaseState++;
            if (chaseState == 1) character.maxWalkSpeed = chaseSpeed1;
            if (chaseState == 2) character.maxWalkSpeed = chaseSpeed2;
        }
    }
}
