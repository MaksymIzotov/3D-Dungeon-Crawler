using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    private Transform playerCam;

    private float mouseX;
    private float mouseY;
    private float desiredX;
    private float xRotation;
    private Vector3 rotation;


    private float headJump = 0;

    private int sensMult = 10;

    CharacterController cc;

    #endregion

    #region Unity Methods

    void Start()
    {
        VariablesAssignment();


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        MouseMovement();
    }
    #endregion

    #region Created Methods

    void MouseMovement()
    {
        //if (InGameUIManager.Instance.state != InGameUIManager.UISTATE.PAUSE)
        //{
            mouseX = Input.GetAxis("Mouse X") * InputManager.Instance.sensitivity * Time.fixedDeltaTime * sensMult;
            mouseY = Input.GetAxis("Mouse Y") * InputManager.Instance.sensitivity * Time.fixedDeltaTime * sensMult;
        //}
        //else
        //{
        //    mouseX = 0;
        //    mouseY = 0;
        //}

        if (Input.GetKey(InputManager.Instance.Aim))
        {
            mouseX *= InputManager.Instance.aimMult;
            mouseY *= InputManager.Instance.aimMult;
        }

        rotation = transform.localRotation.eulerAngles;
        desiredX = rotation.y + mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        headJump = Mathf.Clamp(Mathf.Lerp(headJump, cc.velocity.y, 0.05f), -10, 10);

        playerCam.localRotation = Quaternion.Euler(xRotation + headJump, 0, 0);
        gameObject.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
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
