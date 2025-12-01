using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class InventoryEntry
    {
        public DieFaceSO Face { get; private set; }
        public int InUseDieId { get; set; } //the die ID of the die this face is currently attached to; 0 if the face is currently unused

        public InventoryEntry(DieFaceSO face)
        {
            Face = face;
        }
    }
}
