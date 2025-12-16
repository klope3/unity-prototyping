using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class DiceEditor : MonoBehaviour
    {
        [SerializeField] private GameObject editorUIParent;
        [SerializeField] private DieFaceList dieFaceList;
        [SerializeField] private TMPro.TextMeshProUGUI selectedFaceDebugText;
        public int SelectedDieId { get; private set; }
        public int SelectedFaceId { get; private set; }

        public void StartEditing(int dieId)
        {
            SelectedDieId = dieId;
            editorUIParent.SetActive(true);
            dieFaceList.UpdateList();
        }

        public void StopEditing()
        {
            editorUIParent.SetActive(false);
            SetSelectedFaceId(0);
        }

        public void SetSelectedFaceId(int id)
        {
            SelectedFaceId = id;
            selectedFaceDebugText.text = SelectedFaceId != 0 ? $"Face {SelectedFaceId} selected" : "No face selected";
        }
    }
}
