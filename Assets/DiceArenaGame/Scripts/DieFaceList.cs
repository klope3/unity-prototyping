using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class DieFaceList : MonoBehaviour
    {
        [SerializeField] private DieFaceSelectButton faceButton1;
        [SerializeField] private DieFaceSelectButton faceButton2;
        [SerializeField] private DieFaceSelectButton faceButton3;
        [SerializeField] private DieFaceSelectButton faceButton4;
        [SerializeField] private DieFaceSelectButton faceButton5;
        [SerializeField] private DieFaceSelectButton faceButton6;
        [SerializeField] private DiceEditor diceEditor;
        [SerializeField] private DiceManager diceManager;

        public void UpdateList()
        {
            faceButton1.UpdateButton(diceManager.GetFace(diceEditor.SelectedDieId, 1));
            faceButton2.UpdateButton(diceManager.GetFace(diceEditor.SelectedDieId, 2));
            faceButton3.UpdateButton(diceManager.GetFace(diceEditor.SelectedDieId, 3));
            faceButton4.UpdateButton(diceManager.GetFace(diceEditor.SelectedDieId, 4));
            faceButton5.UpdateButton(diceManager.GetFace(diceEditor.SelectedDieId, 5));
            faceButton6.UpdateButton(diceManager.GetFace(diceEditor.SelectedDieId, 6));
        }
    }
}
