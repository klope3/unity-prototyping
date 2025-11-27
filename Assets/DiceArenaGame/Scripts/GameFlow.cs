using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private HealthHandler die1Health;
        [SerializeField] private HealthHandler die2Health;
        [SerializeField] private HealthHandler die3Health;
        [SerializeField] private HealthHandler die4Health;
        [SerializeField] private GameObject defeatScreen;

        public void CheckGameStatus()
        {
            if (die1Health.CurHealth <= 0 && die2Health.CurHealth <= 0 && die3Health.CurHealth <= 0 && die4Health.CurHealth <= 0) DoDefeat();
        }

        private void DoDefeat()
        {
            defeatScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
