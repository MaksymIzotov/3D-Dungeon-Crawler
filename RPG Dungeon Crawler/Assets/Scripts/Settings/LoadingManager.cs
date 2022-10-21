using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public void LoadLevel()
    {
        StartCoroutine(LoadSceneAsync(1));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        MenuManager.Instance.OpenMenu("loading");

        while (!operation.isDone) {
            //Loading animation

            yield return null;
        }
    }
}
