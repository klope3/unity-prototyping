using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceArenaGame
{
    public class InventoryFaceList : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private InventoryFaceButton listItemPf;
        [SerializeField] private RectTransform listItemsParent;

        private void Awake()
        {
            inventory.OnAddFace += Inventory_OnAddFace;
            Debug.Log("run");
        }

        private void Start()
        {
            gameObject.SetActive(false);
            Debug.Log("start");
        }

        private void Inventory_OnAddFace(InventoryEntry entry)
        {
            Debug.Log("call");
            InventoryFaceButton button = Instantiate(listItemPf, listItemsParent);
            button.SetValues(entry.Face.faceName);
        }
    }
}
