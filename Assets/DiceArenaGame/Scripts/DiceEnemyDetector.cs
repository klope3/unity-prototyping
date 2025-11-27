using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class DiceEnemyDetector : MonoBehaviour
    {
        [SerializeField] private DiceEnemy diceEnemy;

        private void OnTriggerEnter(Collider other)
        {
            Die die = other.GetComponent<Die>();
            if (die == null) return;

            diceEnemy.AddDie(die);
        }

        private void OnTriggerExit(Collider other)
        {
            Die die = other.GetComponent<Die>();
            if (die == null) return;

            diceEnemy.RemoveDie(die);
        }
    }
}
