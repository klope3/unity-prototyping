using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace DiceArenaGame
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private DieFaceSO points10;
        [SerializeField] private DieFaceSO points20;
        [SerializeField] private DieFaceSO attack;
        private List<InventoryEntry> e; //all inventory entries
        [ShowInInspector]
        public List<InventoryEntry> Entries
        {
            get
            {
                if (e == null) e = new List<InventoryEntry>();
                return e;
            }
        }
        public delegate void InventoryEntryEvent(InventoryEntry entry);
        public event InventoryEntryEvent OnAddFace;

        [Button]
        public void AddFace(DieFaceSO face)
        {
            InventoryEntry entry = new InventoryEntry(face);
            Entries.Add(entry);
            OnAddFace?.Invoke(entry);
        }

        public void AssignFaceInInventory(DieFaceSO face, int dieId)
        {
            foreach (InventoryEntry entry in Entries)
            {
                if (entry.Face == face)
                {
                    entry.InUseDieId = dieId;
                    return;
                }
            }
            throw new System.Exception("Face is not in inventory!");
        }
    }
}
