using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    public class GamePoints : MonoBehaviour
    {
        [SerializeField] private GamePointsDisplay gamePointsDisplay;
        public int Points { get; private set; }

        public void Add(int amount)
        {
            Points += amount;
            gamePointsDisplay.UpdateDisplay();
        }
    }
}
