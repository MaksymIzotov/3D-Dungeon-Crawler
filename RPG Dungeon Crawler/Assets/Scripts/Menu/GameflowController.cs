using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameflowController : MonoBehaviour
{
    private void Start()
    {
        TabManager.Instance.OpenTab("input");
        MenuManager.Instance.OpenMenu("main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
