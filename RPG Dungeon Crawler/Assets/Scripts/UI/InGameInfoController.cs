using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameInfoController : MonoBehaviour
{
    GameObject minimapCamera;

    private void Start()
    {
        minimapCamera = GameObject.Find("MinimapCamera");
        minimapCamera.transform.position = new Vector3(transform.position.x, minimapCamera.transform.position.y, transform.position.z);
        minimapCamera.transform.parent = transform;
    }

    public void ToggleOn(InputAction.CallbackContext context)
    {
        PassiveDescriptionShow.Instance.Toggle(true);

        minimapCamera.GetComponent<Camera>().orthographicSize = 200;
        minimapCamera.transform.parent = null;
        minimapCamera.transform.position = new Vector3(125, minimapCamera.transform.position.y, 125);
        minimapCamera.transform.eulerAngles = new Vector3(90, 0, 0);

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

        minimapCamera.GetComponent<Camera>().orthographicSize = 150;
        minimapCamera.transform.position = new Vector3(transform.position.x, minimapCamera.transform.position.y, transform.position.z);
        minimapCamera.transform.parent = transform;

        //Showing hints for totems
        List<GameObject> totems = LevelManager.Instance.GetCurrentTotems;

        foreach (GameObject totem in totems)
        {
            if (totem.transform.GetComponentInChildren<HintTextController>() != null)
                totem.transform.GetComponentInChildren<HintTextController>().TurnOff();
        }
    }
}
