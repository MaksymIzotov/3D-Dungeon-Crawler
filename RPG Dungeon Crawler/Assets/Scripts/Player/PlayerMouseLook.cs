using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseLook : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    private Transform playerCam;
    [SerializeField] private Transform playerCamHolder;

    private float mouseX;
    private float mouseY;
    private float desiredX;
    private float xRotation;
    private Vector3 rotation;

    [SerializeField] private float cameraPosOffset = 1f;

    private float headJump = 0;

    CharacterController cc;

    [SerializeField] private InputActionReference mouseInput;

    [SerializeField] private CurrentSettings settings;

    #endregion

    #region Unity Methods

    void Start()
    {
        VariablesAssignment();
    }

    void Update()
    {
        if (GameStates.Instance.state != GameStates.STATE.PLAY) { return; }

        SetCameraPosition();
        MouseMovement();
    }
    #endregion

    #region Created Methods

    void MouseMovement()
    {
        Vector2 targetMouseDelta = Mouse.current.delta.ReadValue() * Time.fixedDeltaTime;
        mouseX = targetMouseDelta.x * settings.sensitivity;
        mouseY = targetMouseDelta.y * settings.sensitivity;

        rotation = transform.localRotation.eulerAngles;
        desiredX = rotation.y + mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        headJump = Mathf.Clamp(Mathf.Lerp(headJump, cc.velocity.y, 0.05f), -10, 10);

        playerCam.localRotation = Quaternion.Euler(xRotation + headJump, 0, 0);
        gameObject.transform.localRotation = Quaternion.Euler(0, desiredX, 0); 
    }

    private void SetCameraPosition()
    {
        playerCamHolder.localPosition = new Vector3(playerCamHolder.localPosition.x, cc.height - cameraPosOffset, playerCamHolder.localPosition.z);
    }


    #endregion

    #region Technical Methods

    void VariablesAssignment()
    {
        playerCam = GetComponentInChildren<Camera>().transform;
        cc = GetComponent<CharacterController>();
    }

    #endregion
}
