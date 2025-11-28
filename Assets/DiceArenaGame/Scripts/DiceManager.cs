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
