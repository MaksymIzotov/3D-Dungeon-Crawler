using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Public Variables

    [Tooltip("Multiplier of walking speed")]
    public float walkSpeed = 5f;
    [Tooltip("Multiplier of running speed")]
    public float runSpeed = 8f;
    [Tooltip("Gravity forces that applies to the player")]
    public float gravity = 19.6f;
    [Tooltip("Amount of force will apply to the player when jumping")]
    public float jumpForce = 5f;
    [Tooltip("Height of ducking")]
    public float crouchHeight = 0.5f;
    [Tooltip("Time to duck")]
    public float crouchTime = 1f;
    [Tooltip("Movement speed while crouching")]
    public float crouchSpeed = 1f;
    [Tooltip("A step to change speed between walking and running")]
    public float speedChangingStep = 0.5f;


    #endregion

    #region Private Variables
    private CharacterController cc;

    private Vector3 playerVelocity;
    private Vector3 movement;

    [HideInInspector]
    public float speed;

    private float currentHeight;

    private float moveX;
    private float moveY;
    private bool isJumping;
    private bool isCrouching;
    [HideInInspector]
    public bool isRunning;

    private Vector3 impact = Vector3.zero;

    private Transform playerCam;

    private RebindJumping input;
    [SerializeField] private InputActionReference movementInput;

    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        input = InputManager.inputActions;

        input.GameControls.Jump.started += Jump;
        input.GameControls.Run.started += Run;
        input.GameControls.Run.canceled += Walk;


        input.GameControls.Enable();
    }

    private void OnDisable()
    {
        input.GameControls.Disable();
    }

    void Start()
    {
        VariablesAssignment();

        currentHeight = cc.height;
        speed = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        //if (InGameUIManager.Instance.state == InGameUIManager.UISTATE.PAUSE) { return; } RECREATE IN THE FUTURE

        HandleInput();
        //Jump();
    }

    #endregion

    #region Created Methods

    void MovePlayer()
    {
        //if (isGrounded && InGameUIManager.Instance.state == InGameUIManager.UISTATE.PAUSE)
        //{
        //    moveX = 0;
        //    moveY = 0;
        //}

        if (cc.isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        if (cc.isGrounded)
            movement = Quaternion.Euler(0, playerCam.transform.eulerAngles.y, 0) * new Vector3(movementInput.action.ReadValue<Vector2>().x, 0, movementInput.action.ReadValue<Vector2>().y);
        else
            movement += Quaternion.Euler(0, playerCam.transform.eulerAngles.y, 0) * new Vector3(movementInput.action.ReadValue<Vector2>().x, 0, movementInput.action.ReadValue<Vector2>().y) * 0.02f;


        movement = Vector3.ClampMagnitude(movement, 1);

        SpeedHandle();

        cc.Move(movement * speed * Time.deltaTime);

        if (impact.magnitude > 0.2) cc.Move(impact * Time.deltaTime);

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
        //isGrounded = cc.isGrounded;
    }

    void SpeedHandle()
    {
        if (!cc.isGrounded) { return; }

        if (cc.height < currentHeight - 1f) { speed = crouchSpeed; return; }

        if (isRunning)
            speed = runSpeed;
        else
            speed = walkSpeed;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (cc.isGrounded)
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
    }

    public void AddImpact(Transform explosionPos, float force)
    {
        playerVelocity.y = 0;

        Vector3 dir = explosionPos.position - transform.position;
        dir.Normalize();
        impact = (-dir * force) / Vector3.Distance(explosionPos.position, transform.position) / 2;
    }

    void HandleInput()
    {
        //if (Input.GetKey(InputManager.Instance.Forward) && Input.GetKey(InputManager.Instance.Backward) || !Input.GetKey(InputManager.Instance.Forward) && !Input.GetKey(InputManager.Instance.Backward))
        //{
        //    moveY = Mathf.Lerp(moveY, 0, speedChangingStep * Time.deltaTime);
        //}
        //else
        //{
        //    if (Input.GetKey(InputManager.Instance.Forward))
        //        moveY = Mathf.Lerp(moveY, 1, speedChangingStep * Time.deltaTime);
        //    if (Input.GetKey(InputManager.Instance.Backward))
        //        moveY = Mathf.Lerp(moveY, -1, speedChangingStep * Time.deltaTime);
        //}

        //if (Input.GetKey(InputManager.Instance.Left) && Input.GetKey(InputManager.Instance.Right) || !Input.GetKey(InputManager.Instance.Left) && !Input.GetKey(InputManager.Instance.Right))
        //{
        //    moveX = Mathf.Lerp(moveX, 0, speedChangingStep * Time.deltaTime);
        //}
        //else
        //{
        //    if (Input.GetKey(InputManager.Instance.Right))
        //        moveX = Mathf.Lerp(moveX, 1, speedChangingStep * Time.deltaTime);
        //    if (Input.GetKey(InputManager.Instance.Left))
        //        moveX = Mathf.Lerp(moveX, -1, speedChangingStep * Time.deltaTime);
        //}

        //isJumping = Input.GetKeyDown(InputManager.Instance.Jump);
        //isRunning = Input.GetKey(InputManager.Instance.Run);
        //isCrouching = Input.GetKey(InputManager.Instance.Crouch);
    }

    private void Run(InputAction.CallbackContext context) => isRunning = true;
    private void Walk(InputAction.CallbackContext context) => isRunning = false;
    #endregion

    #region Technical Methods

    public Vector3 GetMovement() { return movement; }
    public bool GetIsGrounded() { return cc.isGrounded; }

    void VariablesAssignment()
    {
        cc = GetComponent<CharacterController>();
        playerCam = GetComponentInChildren<Camera>().transform;
    }

    #endregion
}