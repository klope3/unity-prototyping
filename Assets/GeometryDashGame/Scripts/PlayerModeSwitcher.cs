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

        public void ToggleShip()
        {
            bool ship = playerMovement.CurMovementType == PlayerMovement.MovementType.Normal;
            mainVisual.SetActive(!ship);
            shipVisual.SetActive(ship);
            playerMovement.SetMovementType(ship ? PlayerMovement.MovementType.Ship : PlayerMovement.MovementType.Normal);
        }
    }
}
