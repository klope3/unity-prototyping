using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerModeSwitcher switcher = collision.GetComponent<PlayerModeSwitcher>();
            if (switcher != null) switcher.ActivateShip();
        }
    }
}
