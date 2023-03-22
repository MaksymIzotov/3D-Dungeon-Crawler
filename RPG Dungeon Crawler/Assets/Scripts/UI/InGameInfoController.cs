using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameInfoController : MonoBehaviour
{
    private void Start()
    {
        GameObject minimapCamera = GameObject.Find("MinimapCamera");
        minimapCamera.transform.position = new Vector3(transform.position.x, minimapCamera.transform.position.y, transform.position.z);
        minimapCamera.transform.parent = transform;
    }

    public void ToggleOn(InputAction.CallbackContext context)
    {
        PassiveDescriptionShow.Instance.Toggle(true);

        //Showing hints for totems
        List<GameObject> totems = LevelManager.Instance.GetCurrentTotems;

        foreach (GameObject totem in totems)
        {
            if (totem.transform.GetComponentInChildren<HintTextController>() != null)
                totem.transform.GetComponentInChildren<HintTextController>().TurnOn();
        }
    }

    public void ToggleOff(InputAction.CallbackContext context)
    {
        PassiveDescriptionShow.Instance.Toggle(false);

        //Showing hints for totems
        List<GameObject> totems = LevelManager.Instance.GetCurrentTotems;

        foreach (GameObject totem in totems)
        {
            if (totem.transform.GetComponentInChildren<HintTextController>() != null)
                totem.transform.GetComponentInChildren<HintTextController>().TurnOff();
        }
    }
}
