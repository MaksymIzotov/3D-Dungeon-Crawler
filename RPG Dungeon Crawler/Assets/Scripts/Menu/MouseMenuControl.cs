using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMenuControl : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private Camera cam;

    GameObject hitGO;
    GameObject lastHitGO;

    private void OnEnable()
    {
        hitGO = null;
        lastHitGO = null;
    }

    void Update()
    { 
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            hitGO = hit.collider.gameObject;
            //activate
            if (hitGO.TryGetComponent(out TableItemsInteraction tableItemsInteraction))
            {
                tableItemsInteraction.OnMouseAbove();
            }

            //deactivate
            if (lastHitGO == null) { return; }

            if (hitGO != lastHitGO)
            {
                if (lastHitGO.TryGetComponent(out TableItemsInteraction tableItemsInteraction1))
                {
                    tableItemsInteraction1.OnMouseAway();
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (hitGO == null) { return; }
        lastHitGO = hitGO;
    }
}

