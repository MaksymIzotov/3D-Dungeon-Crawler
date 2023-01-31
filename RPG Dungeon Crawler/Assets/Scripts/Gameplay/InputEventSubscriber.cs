using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventSubscriber : MonoBehaviour
{
    private RebindJumping input;

    PlayerController pc;
    SpellsInventory si;
    InteractionController ic;
    InGameInfoController igic;
    PlayerItemController pic;
    PlayerAudio pa;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        si = GetComponent<SpellsInventory>();
        ic = GetComponent<InteractionController>();
        igic = GetComponent<InGameInfoController>();
        pic = GetComponent<PlayerItemController>();
        pa = GetComponent<PlayerAudio>();
    }

    private void OnEnable()
    {
        if (input == null)
            input = InputManager.inputActions;

        input.GameControls.Jump.started += pc.Jump;
        input.GameControls.Run.started += pc.Run;
        input.GameControls.Run.canceled += pc.Walk;

        input.GameControls.Spell01.started += si.Spell01Cast;
        input.GameControls.Spell02.started += si.Spell02Cast;
        input.GameControls.Spell03.started += si.Spell03Cast;
        input.GameControls.Spell04.started += si.Spell04Cast;

        input.GameControls.Usable.started += pic.UseUsable;

        input.GameControls.Interact.started += ic.Interact;

        input.GameControls.Info.started += igic.ToggleOn;
        input.GameControls.Info.canceled += igic.ToggleOff;

        input.GameControls.Movement.started += pa.Walk;
        input.GameControls.Movement.canceled += pa.StopWalking;

        input.GameControls.Enable();
    }

    private void OnDisable()
    {
        input.GameControls.Jump.started -= pc.Jump;
        input.GameControls.Run.started -= pc.Run;
        input.GameControls.Run.canceled -= pc.Walk;

        input.GameControls.Spell01.started -= si.Spell01Cast;
        input.GameControls.Spell02.started -= si.Spell02Cast;
        input.GameControls.Spell03.started -= si.Spell03Cast;
        input.GameControls.Spell04.started -= si.Spell04Cast;

        input.GameControls.Usable.started -= pic.UseUsable;

        input.GameControls.Interact.started -= ic.Interact;

        input.GameControls.Info.started -= igic.ToggleOn;
        input.GameControls.Info.canceled -= igic.ToggleOff;

        input.GameControls.Movement.started -= pa.Walk;
        input.GameControls.Movement.canceled -= pa.StopWalking;

        input.GameControls.Disable();
    }
}
