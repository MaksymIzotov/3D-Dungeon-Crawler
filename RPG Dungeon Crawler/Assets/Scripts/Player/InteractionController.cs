using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float distance = 1f;
    [SerializeField] private GameObject cam;

    private bool canInteract = false;

    private RaycastHit hit;

    private void Update()
    {
        TryInteract();
    }

    private void TryInteract()
    { 
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (hit.transform.CompareTag("Interactable")) {
                UIManager.Instance.UpdateInteraction(true, hit.transform.GetComponent<IInteractable>().GetInteractedInfo());

                canInteract = true;
            }
            else
            {
                UIManager.Instance.UpdateInteraction(false, "");
                canInteract = false;
            }
        }
        else
        {
            UIManager.Instance.UpdateInteraction(false, "");
            canInteract = false;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!canInteract) { return; }

        hit.transform.GetComponent<IInteractable>().Interact();
    }
}
