using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryFaceButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetValues(string label)
    {
        text.text = label;
    }
}
