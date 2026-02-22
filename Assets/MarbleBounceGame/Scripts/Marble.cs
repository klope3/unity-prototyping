using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

namespace MarbleBounceGame
{
    public class Marble : MonoBehaviour
    {
        [SerializeField] private MMF_Player floatingTextPlayer;
        private GamePoints gamePoints;

        private void Awake()
        {
            gamePoints = FindObjectOfType<GamePoints>();
        }

        public void DoBounce()
        {
            gamePoints.Add(100);
            if (floatingTextPlayer.GetFeedbackOfType<MMF_FloatingText>() == null)
            {
                Debug.LogError("Null");
            }
            floatingTextPlayer.GetFeedbackOfType<MMF_FloatingText>().Value = $"+{100}";
            floatingTextPlayer.PlayFeedbacks();
        }
    }
}
