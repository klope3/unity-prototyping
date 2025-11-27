using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    [CreateAssetMenu(fileName = "DieFaceSO", menuName = "Scriptable Objects/DiceArenaGame/DieFaceSO")]
    public class DieFaceSO : ScriptableObject
    {
        [SerializeField] public string faceName;
        [SerializeField] public FaceType faceType;
        [SerializeField] public int points;
        [SerializeField] public int attackStrength;
        [SerializeField] public float attackRange;
        [SerializeField] public int multiplier;
        [SerializeField] public int repairAmount;

        public enum FaceType
        {
            Points,
            Multiplier,
            Attack,
            RepairSelf,
            RepairNeighbor
        }
    }
}
