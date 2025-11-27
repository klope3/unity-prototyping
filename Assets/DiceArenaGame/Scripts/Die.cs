using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

namespace DiceArenaGame
{
    public class Die : MonoBehaviour, IClickableObject
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float spinForce;
        [SerializeField] private float spinTime;
        [SerializeField] public DieFaceSO face1;
        [SerializeField] public DieFaceSO face2;
        [SerializeField] public DieFaceSO face3;
        [SerializeField] public DieFaceSO face4;
        [SerializeField] public DieFaceSO face5;
        [SerializeField] public DieFaceSO face6;
        [SerializeField] private TextMeshProUGUI face1DebugText;
        [SerializeField] private TextMeshProUGUI face2DebugText;
        [SerializeField] private TextMeshProUGUI face3DebugText;
        [SerializeField] private TextMeshProUGUI face4DebugText;
        [SerializeField] private TextMeshProUGUI face5DebugText;
        [SerializeField] private TextMeshProUGUI face6DebugText;
        [SerializeField] private PointHandler pointHandler;
        private bool rolling;

        private void Awake()
        {
            UpdateDebugText();
        }

        [Button]
        public void Roll()
        {
            if (rolling) return;
            StartCoroutine(CO_Roll());
        }

        private IEnumerator CO_Roll()
        {
            rolling = true;

            rb.AddTorque(Vector3.one * spinForce, ForceMode.Impulse);
            yield return new WaitForSeconds(spinTime);
            rb.angularVelocity = Vector3.zero;

            int rand = Random.Range(1, 7);
            ExecuteFace(rand);
            SetFaceAngle(rand);

            rolling = false;
        }

        public void SetFaceAngle(int face)
        {
            if (face == 1) rb.transform.eulerAngles = new Vector3(0, 45, 0);
            if (face == 2) rb.transform.eulerAngles = new Vector3(0, 45, 90);
            if (face == 3) rb.transform.eulerAngles = new Vector3(-90, 45, 0);
            if (face == 4) rb.transform.eulerAngles = new Vector3(90, 45, 0);
            if (face == 5) rb.transform.eulerAngles = new Vector3(0, -45, -90);
            if (face == 6) rb.transform.eulerAngles = new Vector3(180, 45, 0);
        }

        public void ExecuteFace(int face)
        {
            DieFaceSO dieFace = ChooseFace(face);

            if (dieFace.faceType == DieFaceSO.FaceType.Points) pointHandler.AddPoints(dieFace.points);
            if (dieFace.faceType == DieFaceSO.FaceType.Attack) Debug.Log($"Attack {dieFace.attackStrength}!");
            if (dieFace.faceType == DieFaceSO.FaceType.Multiplier) Debug.Log($"Multiplier {dieFace.multiplier}!");
            if (dieFace.faceType == DieFaceSO.FaceType.RepairSelf) Debug.Log($"Repair self {dieFace.repairAmount}!");
            if (dieFace.faceType == DieFaceSO.FaceType.RepairNeighbor) Debug.Log($"Repair neighbor {dieFace.repairAmount}!");
        }

        private DieFaceSO ChooseFace(int face)
        {
            if (face == 1) return face1;
            if (face == 2) return face2;
            if (face == 3) return face3;
            if (face == 4) return face4;
            if (face == 5) return face5;
            if (face == 6) return face6;
            return null;
        }

        [Button]
        public void UpdateDebugText()
        {
            face1DebugText.text = face1.faceName;
            face2DebugText.text = face2.faceName;
            face3DebugText.text = face3.faceName;
            face4DebugText.text = face4.faceName;
            face5DebugText.text = face5.faceName;
            face6DebugText.text = face6.faceName;
        }

        public void Click()
        {
            Roll();
        }
    }
}
