using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class BasicLootContainer : MonoBehaviour
    {
        [SerializeField] private int ammoAmount;
        [SerializeField] private int healthAmount;
        private bool looted;

        public void Loot(SimpleGun playerGun, HealthHandler playerHealth)
        {
            if (looted)
            {
                Debug.Log("Already looted");
                return;
            }

            if (Random.Range(0, 1f) < 0.5f)
            {
                playerGun.AddAmmo(ammoAmount);
                Debug.Log("Obtained ammo");
            } else
            {
                playerHealth.AddHealth(healthAmount, transform.position);
                Debug.Log("Obtained health");
            }
            looted = true;
        }
    }
}
