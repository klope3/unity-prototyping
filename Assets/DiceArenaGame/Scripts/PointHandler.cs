using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DiceArenaGame
{
    public class PointHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointText;
        private int points;

        public void AddPoints(int amount)
        {
            points = Mathf.Clamp(points + amount, 0, int.MaxValue);
            pointText.text = $"{points}";
        }
    }
}
