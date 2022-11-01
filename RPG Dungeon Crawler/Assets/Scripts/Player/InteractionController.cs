using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float distance = 1f;


    private void Update()
    {
        TryInteract();
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (hit.transform.CompareTag("Interactable")) {
                UIManager.Instance.UpdateInteraction(true, hit.transform.GetComponent<IInteractable>().GetInteractedInfo());
            }
            else
            {
                UIManager.Instance.UpdateInteraction(false, "");
            }
        }
        else
        {
            UIManager.Instance.UpdateInteraction(false, ""); 
        }
    }
}
