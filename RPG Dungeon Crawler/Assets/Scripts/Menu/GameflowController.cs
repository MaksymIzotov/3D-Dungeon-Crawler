using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameflowController : MonoBehaviour
{
    [SerializeField] private CurrentSettings settings;
    public UnityEvent onContinuePlaying;
    public UnityEvent onNewGameStarted;

    private void Start()
    {
        TabManager.Instance.OpenTab("input");
        MenuManager.Instance.OpenMenu("main");

        if (settings.isPlaying)
            onContinuePlaying.Invoke();
    }
        

    public void StartGame()
    {
        settings.isPlaying = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
