using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float distance = 1f;

    private RebindJumping input;
    private bool canInteract = false;

    private RaycastHit hit;

    private void Start()
    {
        input = InputManager.inputActions;

        input.GameControls.Interact.started += Interact;
    }

    private void Update()
    {
        TryInteract();
    }

    private void TryInteract()
    { 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
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

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("ASDSAD");
        if (!canInteract) { return; }

        hit.transform.GetComponent<IInteractable>().Interact();
    }
}
