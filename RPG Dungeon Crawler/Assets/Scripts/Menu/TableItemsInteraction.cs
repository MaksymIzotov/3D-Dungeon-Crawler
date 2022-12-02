using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableItemsInteraction : MonoBehaviour
{
    public UnityEvent onClick;
    private bool isOn;

    [SerializeField] private GameObject text;

    private void Update()
    {
        if (!isOn) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseAway();
            onClick.Invoke();
        }
    }

    public void OnMouseAbove()
    {
        if (isOn) { return; }

        //Toggle things
        text.SetActive(true);
        transform.localScale *= 1.1f;
        isOn = true;
    }

    public void OnMouseAway()
    {
        //Untoggle things
        text.SetActive(false);
        transform.localScale /= 1.1f; 
        isOn = false;
    }
}
