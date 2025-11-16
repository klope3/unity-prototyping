using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CityFPSGame
{
    public class SimpleGun : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private Transform muzzlePoint;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private int maxAmmo;
        [SerializeField] private ParticleSystem impactEffect;
        private int ammo;
        public int Ammo
        {
            get
            {
                return ammo;
            }
        }

        public UnityEvent OnFire;
        public UnityEvent OnAmmoChange;

        private void Awake()
        {
            ammo = maxAmmo;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (ammo <= 0) return;

                AddAmmo(-1);
                bool hit = Physics.Raycast(new Ray(muzzlePoint.position, muzzlePoint.forward), out RaycastHit hitInfo, 10000, layerMask);
                OnFire?.Invoke();
                if (!hit) return;

                impactEffect.transform.position = hitInfo.point;
                impactEffect.Play();

                HealthHandler health = hitInfo.collider.GetComponent<HealthHandler>();
                if (health == null) return;

                health.AddHealth(-1 * damage, hitInfo.point);
            }
        }

        public void AddAmmo(int amount)
        {
            ammo = Mathf.Clamp(ammo + amount, 0, maxAmmo);
            OnAmmoChange?.Invoke();
        }
    }
}
