using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class Inventory : MonoBehaviour
    {
        private List<InventoryEntry> e; //all inventory entries
        public List<InventoryEntry> Entries
        {
            get
            {
                if (e == null) e = new List<InventoryEntry>();
                return e;
            }
        }

        [Sirenix.OdinInspector.Button]
        public void AddFace(DieFaceSO face)
        {
            Entries.Add(new InventoryEntry(face));
        }
    }
}
