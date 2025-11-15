using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CityFPSGame
{
    public class AmmoCounter : MonoBehaviour
    {
        [SerializeField] private SimpleGun simpleGun;
        [SerializeField] private TextMeshProUGUI counterText;

        private void Awake()
        {
            UpdateCounter();
        }

        public void UpdateCounter()
        {
            counterText.text = $"Ammo {simpleGun.Ammo}";
        }
    }
}
