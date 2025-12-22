using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectClicker : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, layerMask);

            if (!hit) return;
            IClickableObject clickable = hitInfo.collider.GetComponent<IClickableObject>();
            if (clickable == null) return;
            clickable.Click();
        }
    }
}
