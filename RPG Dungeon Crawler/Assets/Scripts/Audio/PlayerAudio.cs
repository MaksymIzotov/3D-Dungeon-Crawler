using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAudio : AudioController
{
    public Audio Footsteps;
    public Audio JumpLand;

    private CharacterController characterController;
    private AudioSource audioSource;
    private PlayerController playerController;

    private bool isWalking = false;
    private bool hasJumped = false;
    private float stepCoolDown;
    [SerializeField] private float walkingStepRate = 1;
    [SerializeField] private float runningStepRate = 1;
    [SerializeField] private float jumpImpactDelay = 0.5f;

    private float stepRate = 1;
    private float jumpTimer;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();

        stepCoolDown = walkingStepRate;
        jumpTimer = jumpImpactDelay;
    }

    private void Update()
    {
        CheckJumpImpact();

        stepRate = playerController.isRunning ? runningStepRate : walkingStepRate;

        if (!characterController.isGrounded) { return; }
        if (!isWalking) { return; }

        stepCoolDown -= Time.deltaTime;

        if (stepCoolDown < 0f)
        {
            PlayAudio(audioSource, Footsteps);

            stepCoolDown = stepRate;
        }
    }

    private void CheckJumpImpact()
    {
        if (!characterController.isGrounded)
        {
            hasJumped = true;
            jumpTimer -= Time.deltaTime;
        }

        if (characterController.isGrounded)
        {
            if (jumpTimer <= 0)
            {
                PlayJumpImpact();
                hasJumped = false;
            }

            jumpTimer = jumpImpactDelay;
        }
    }

    private void PlayJumpImpact()
    {
        PlayAudio(audioSource, JumpLand);
    }

    public void Walk(InputAction.CallbackContext context)
    {
        isWalking = true;
    }

    public void StopWalking(InputAction.CallbackContext context)
    {
        isWalking = false;
    }
}
