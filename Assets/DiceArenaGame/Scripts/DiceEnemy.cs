using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class DiceEnemy : MonoBehaviour
    {
        [SerializeField] private ECM2.Character character;
        [SerializeField] private float attackDistance;
        [SerializeField] private float cooldownTime;
        private Die targetDie;

        private bool cooldown;
        private List<Die> d; //dice
        private List<Die> DetectedDice
        {
            get
            {
                if (d == null) d = new List<Die>();
                return d;
            }
        }

        private void Update()
        {
            targetDie = ChooseTarget();
            if (targetDie == null)
            {
                character.SetMovementDirection(Vector3.zero);
                return;
            }

            Vector3 vec = targetDie.transform.position - transform.position;
            float distance = vec.magnitude;

            if (distance > attackDistance)
            {
                character.SetMovementDirection(vec);
            } else
            {
                character.SetMovementDirection(Vector3.zero);
                if (!cooldown) StartCoroutine(CO_Attack());
            }
        }

        private IEnumerator CO_Attack()
        {
            cooldown = true;
            HealthHandler health = targetDie.GetComponent<HealthHandler>();
            health.AddHealth(-1, transform.position);
            yield return new WaitForSeconds(cooldownTime);
            cooldown = false;
        }

        private Die ChooseTarget()
        {
            if (DetectedDice.Count == 0) return null;
            Die die = DetectedDice[0];
            float bestDistance = float.MaxValue;

            foreach (Die d in DetectedDice) 
            {
                HealthHandler health = d.GetComponent<HealthHandler>();
                if (health.CurHealth <= 0) continue;

                float distance = Vector3.Distance(d.transform.position, transform.position);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    die = d;
                }
            }

            return die;
        }

        public void AddDie(Die die)
        {
            if (DetectedDice.Contains(die)) return;

            DetectedDice.Add(die);
        }

        public void RemoveDie(Die die)
        {
            DetectedDice.Remove(die);
        }
    }
}
