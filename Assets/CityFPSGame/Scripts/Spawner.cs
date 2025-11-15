using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefabToSpawn;
        [SerializeField] private int maxSpawned;
        [SerializeField] private float spawnInterval;
        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer < spawnInterval) return;

            int existingSpawned = transform.childCount;
            if (existingSpawned >= maxSpawned) return;

            Instantiate(prefabToSpawn, transform);
            timer = 0;
        }
    }
}
