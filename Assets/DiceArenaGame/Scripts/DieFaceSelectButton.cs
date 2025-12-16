using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DiceArenaGame
{
    public class DieFaceSelectButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI debugText;

        public void UpdateButton(DieFaceSO face)
        {
            debugText.text = face != null ? face.faceName : "-";
        }
    }
}
