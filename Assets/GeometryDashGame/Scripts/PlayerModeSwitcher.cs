using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDashGame
{
    public class PlayerModeSwitcher : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private GameObject mainVisual;
        [SerializeField] private GameObject shipVisual;

        public void ActivateShip()
        {
            mainVisual.SetActive(false);
            shipVisual.SetActive(true);
            playerMovement.SetMovementType(PlayerMovement.MovementType.Ship);
        }
    }
}
