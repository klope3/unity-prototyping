using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    public class ClickMode : MonoBehaviour
    {
        [SerializeField] private MarbleNudger nudger;
        [SerializeField] private PiecePlacer placer;
        private bool placeMode;

        public void ToggleMode()
        {
            placeMode = !placeMode;

            nudger.enabled = !placeMode;
            placer.enabled = placeMode;
        }
    }
}
