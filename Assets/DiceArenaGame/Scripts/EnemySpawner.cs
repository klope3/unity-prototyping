using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPf;
        [SerializeField] private float spawnTime;
        [SerializeField] private int maxEnemies;
        [SerializeField] private float spawnDistance;
        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer < spawnTime) return;

            int curEnemies = transform.childCount;
            if (curEnemies >= maxEnemies) return;

            Vector3 randPosition = Random.insideUnitSphere;
            randPosition.y = 0;
            Vector3 adjustedPosition = randPosition.normalized * spawnDistance;
            GameObject spawned = Instantiate(enemyPf, transform);
            spawned.transform.position = transform.position + adjustedPosition;
            HealthHandler health = spawned.GetComponent<HealthHandler>();
            if (health != null) health.Initialize();

            timer = 0;
        }
    }
}
