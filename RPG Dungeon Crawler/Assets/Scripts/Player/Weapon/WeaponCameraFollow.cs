using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponCameraFollow : MonoBehaviour
{
    #region Public Variables
    [Tooltip("Amount of weapon sway to be applied")]
    public float swayAmount = 0;

    #endregion

    #region Private Variables

    private float mouseX;
    private float mouseY;

    private PlayerMouseLook mouseSettings;
    [SerializeField] private InputActionReference mouseInput;

    #endregion

    #region Unity Methods
    void Start()
    {
        VariablesAssignment();
    }


    void Update()
    {
        //if (InGameUIManager.Instance.state == InGameUIManager.UISTATE.PAUSE) { return; }

        WeaponSway();
    }

    #endregion

    #region User Methods

    void WeaponSway()
    {
        Vector2 targetMouseDelta = Mouse.current.delta.ReadValue() * Time.smoothDeltaTime;

        mouseX = targetMouseDelta.x * 5 * Time.fixedDeltaTime * swayAmount;
        mouseY = targetMouseDelta.y * 5 * Time.fixedDeltaTime * swayAmount;

        //if (Input.GetKey(InputManager.Instance.Aim))
        //{
        //    mouseX *= InputManager.Instance.aimMult;
        //    mouseY *= InputManager.Instance.aimMult;
        //}

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(new Vector3(Mathf.Clamp(-mouseY , -45, 45), Mathf.Clamp(mouseX, -45, 45), 0)), 0.07f);
    }

    #endregion

    #region Technical Methods

    void VariablesAssignment()
    {
        mouseSettings = transform.parent.root.GetComponent<PlayerMouseLook>();
    }

    #endregion
}