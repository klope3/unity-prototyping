using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MarbleBounceGame
{
    public class GamePointsDisplay : MonoBehaviour
    {
        [SerializeField] private GamePoints gamePoints;
        [SerializeField] private TextMeshProUGUI text;

        public void UpdateDisplay()
        {
            text.text = $"{gamePoints.Points}";
        }
    }
}
