using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityFPSGame
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private HealthHandler health;
        [SerializeField] private SimpleGun gun;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bool hit = Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit hitInfo, maxDistance, layerMask);
                if (!hit) return;
                BasicLootContainer lootContainer = hitInfo.collider.GetComponent<BasicLootContainer>();
                if (lootContainer != null)
                {
                    lootContainer.Loot(gun, health);
                } 
            }
        }
    }
}
