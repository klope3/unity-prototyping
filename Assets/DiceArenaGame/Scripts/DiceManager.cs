using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class DiceManager : MonoBehaviour
    {
        [SerializeField] private Die die1;
        [SerializeField] private Die die2;
        [SerializeField] private Die die3;
        [SerializeField] private Die die4;
        [SerializeField] private DieFaceSO points10;
        [SerializeField] private DieFaceSO points20;
        [SerializeField] private DieFaceSO attack;
        [SerializeField] private Inventory inventory;

        private void Start()
        {
            TestInitialize();
        }

        private void TestInitialize()
        {
            inventory.AddFace(points10);
            inventory.AddFace(points10);
            inventory.AddFace(points20);
            inventory.AddFace(points20);
            inventory.AddFace(attack);
            inventory.AddFace(attack);

            AssignFace(points10, 1, 1);
            AssignFace(points10, 1, 2);
            AssignFace(points20, 1, 3);
            AssignFace(points20, 1, 4);
            AssignFace(attack, 1, 5);
            AssignFace(attack, 1, 6);
        }

        public void AssignFace(DieFaceSO face, int dieId, int dieFaceId)
        {
            inventory.AssignFaceInInventory(face, dieId);
            Die die = ChooseDie(dieId);
            die.SetFace(face, dieFaceId);
        }

        public DieFaceSO GetFace(int dieId, int faceId)
        {
            Die die = ChooseDie(dieId);
            return die.ChooseFace(faceId);
        }

        private Die ChooseDie(int dieId)
        {
            if (dieId == 1) return die1;
            if (dieId == 2) return die2;
            if (dieId == 3) return die3;
            if (dieId == 4) return die4;
            return null;
        }

        public List<Die> GetOrthogonalNeighbors(int requesterId)
        {
            List<Die> neighbors = new List<Die>();
            if (requesterId == 1)
            {
                neighbors.Add(die2);
                neighbors.Add(die3);
                return neighbors;
            }
            if (requesterId == 2)
            {
                neighbors.Add(die1);
                neighbors.Add(die4);
                return neighbors;
            }
            if (requesterId == 3)
            {
                neighbors.Add(die1);
                neighbors.Add(die4);
                return neighbors;
            }
            if (requesterId == 4)
            {
                neighbors.Add(die2);
                neighbors.Add(die3);
                return neighbors;
            }
            return neighbors;
        }
    }
}
