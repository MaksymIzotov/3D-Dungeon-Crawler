using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameInfoController : MonoBehaviour
{
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
