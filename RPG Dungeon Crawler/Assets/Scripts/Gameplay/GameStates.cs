using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStates : MonoBehaviour
{
    #region SingletonInit
    public static GameStates Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private RebindJumping input;

    public enum STATE
    {
        PLAY,
        PAUSE
    }

    public STATE state;

    private void Start()
    {
        state = STATE.PLAY;

        input = InputManager.inputActions;
        input.GameControls.Pause.started += ChangeState;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ChangeState(InputAction.CallbackContext context)
    {
        if (state == STATE.PLAY)
            state = STATE.PAUSE;
        else if (state == STATE.PAUSE)
            state = STATE.PLAY;

        StateChanged();
    }

    public void Continue()
    {
        state = STATE.PLAY;
        StateChanged();
    }

    private void StateChanged()
    {
        switch (state)
        {
            case STATE.PLAY:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                MenuManager.Instance.OpenMenu("gui");
                Time.timeScale = 1;
                break;
            case STATE.PAUSE:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                MenuManager.Instance.OpenMenu("pause");
                Time.timeScale = 0;
                break;
        }
    }
}
