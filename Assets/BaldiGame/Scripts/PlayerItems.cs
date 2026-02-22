using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaldiGame
{
    public class PlayerItems : MonoBehaviour
    {
        [SerializeField] private Balder balder;
        [SerializeField] private Camera cam;
        [SerializeField] private TMPro.TextMeshProUGUI itemCountText;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private int itemsMax;
        private int itemCount;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, layerMask);
                if (!hit) return;

                Destroy(hitInfo.collider.gameObject);
                itemCount++;
                itemCountText.text = $"{itemCount}/{itemsMax}";
                balder.IncrementChaseState();
            }
        }
    }
}
