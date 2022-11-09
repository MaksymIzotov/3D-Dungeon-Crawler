using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class HintTextController : MonoBehaviour
{
    private GameObject player;
    private TMP_Text text;

    private Color textColor = new Color(255,255,255,255);
    private float alpha = 0;

    private RebindJumping input;

    private bool isOn = false;

    private void OnEnable()
    {
        input = InputManager.inputActions;

        input.GameControls.Info.started += TurnOn;
        input.GameControls.Info.canceled += TurnOff;

        //input.GameControls.Enable();
    }

    private void OnDisable()
    {
        input.GameControls.Info.started -= TurnOn;
        input.GameControls.Info.canceled -= TurnOff; 

        //input.GameControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        Rotate();

        if (!isOn) {
            textColor.a = 0;
            text.color = textColor;
            return;
        }

        float dist = Vector3.Distance(transform.parent.position, player.transform.position);
        if(dist < 10)
        {
            alpha = ExtensionMethods.Remap(dist, 5, 10, 0, 1);
            textColor.a = alpha;
        }
        else
        {
            textColor.a = 1;
        }

        text.color = textColor;
    }

    private void Rotate()
    {
        transform.LookAt(player.transform);
    }

    private void TurnOn(InputAction.CallbackContext context) => isOn = true;
    private void TurnOff(InputAction.CallbackContext context) => isOn = false;
}
