using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    public void FinishStartAnimation()
    {
        MenuManager.Instance.OpenMenu("upgrades");
        GetComponent<MouseMenuControl>().enabled = true;
    }

    public void FinishMainAnimation()
    {
        MenuManager.Instance.OpenMenu("main");
    }
}
