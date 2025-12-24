using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBounceGame
{
    public class PiecePlacer : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform ghostTransform;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject piecePf;

        private void Update()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, layerMask);

            if (!hit) return;

            Vector3 snappedPosition = hitInfo.point;
            snappedPosition.x = Mathf.RoundToInt(hitInfo.point.x);
            snappedPosition.z = Mathf.RoundToInt(hitInfo.point.z);

            ghostTransform.position = snappedPosition + Vector3.up * 0.05f;

            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                GameObject newPiece = Instantiate(piecePf);
                newPiece.transform.position = snappedPosition;
            }
        }

        private void OnEnable()
        {
            ghostTransform.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            ghostTransform.gameObject.SetActive(false);
        }
    }
}
