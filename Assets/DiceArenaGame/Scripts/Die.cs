using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Sirenix.OdinInspector;
using MoreMountains.Feedbacks;

namespace DiceArenaGame
{
    public class Die : MonoBehaviour, IClickableObject
    {
        [SerializeField] private DiceManager diceManager;
        [SerializeField] private int dieId;
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
        [SerializeField] private LayerMask attackLayerMask;
        [SerializeField] private MMF_Player floatingTextPlayer;
        private bool rolling;
        public UnityEvent OnAttack;
        private int curFace;
        public DieFaceSO CurFace
        {
            get
            {
                if (curFace == 1) return face1;
                if (curFace == 2) return face2;
                if (curFace == 3) return face3;
                if (curFace == 4) return face4;
                if (curFace == 5) return face5;
                if (curFace == 6) return face6;
                return null;
            }
        }

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
            curFace = 0;

            rb.AddTorque(Vector3.one * spinForce, ForceMode.Impulse);
            yield return new WaitForSeconds(spinTime);
            rb.angularVelocity = Vector3.zero;

            int rand = Random.Range(1, 7);
            curFace = rand;
            ExecuteFace(rand);
            SetFaceAngle(rand);

            rolling = false;
        }

        public void SetFace(DieFaceSO face, int faceId)
        {
            if (faceId == 1) face1 = face;
            if (faceId == 2) face2 = face;
            if (faceId == 3) face3 = face;
            if (faceId == 4) face4 = face;
            if (faceId == 5) face5 = face;
            if (faceId == 6) face6 = face;
            UpdateDebugText();
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
            if (dieFace == null) return;

            if (dieFace.faceType == DieFaceSO.FaceType.Points)
            {
                int points = CalculatePoints(dieFace);
                pointHandler.AddPoints(points);
                floatingTextPlayer.GetFeedbackOfType<MMF_FloatingText>().Value = $"+{points}";
                floatingTextPlayer.PlayFeedbacks();
            }
            if (dieFace.faceType == DieFaceSO.FaceType.Attack) Attack(dieFace);
            if (dieFace.faceType == DieFaceSO.FaceType.Multiplier) Debug.Log($"Multiplier {dieFace.multiplier}!");
            if (dieFace.faceType == DieFaceSO.FaceType.RepairSelf) Debug.Log($"Repair self {dieFace.repairAmount}!");
            if (dieFace.faceType == DieFaceSO.FaceType.RepairNeighbor) Debug.Log($"Repair neighbor {dieFace.repairAmount}!");
        }

        private int CalculatePoints(DieFaceSO face)
        {
            int points = face.points;
            List<Die> neighbors = diceManager.GetOrthogonalNeighbors(dieId);
            foreach (Die neighbor in neighbors)
            {
                DieFaceSO curFace = neighbor.CurFace;
                if (curFace == null) continue;
                if (curFace.faceType != DieFaceSO.FaceType.Multiplier) continue;
                points *= curFace.multiplier;
            }
            return points;
        }

        private void Attack(DieFaceSO face)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, face.attackRange, attackLayerMask);
            foreach (Collider c in colliders)
            {
                HealthHandler health = c.GetComponent<HealthHandler>();
                if (health == null) continue;
                health.AddHealth(-1 * face.attackStrength, c.transform.position);
            }
            OnAttack?.Invoke();
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
            face1DebugText.text = face1 != null ? face1.faceName : "-";
            face2DebugText.text = face2 != null ? face2.faceName : "-";
            face3DebugText.text = face3 != null ? face3.faceName : "-";
            face4DebugText.text = face4 != null ? face4.faceName : "-";
            face5DebugText.text = face5 != null ? face5.faceName : "-";
            face6DebugText.text = face6 != null ? face6.faceName : "-";
        }

        public void Click()
        {
            Roll();
        }
    }
}
