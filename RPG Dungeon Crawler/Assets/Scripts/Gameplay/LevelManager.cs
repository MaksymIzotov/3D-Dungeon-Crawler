using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region SingletonInit
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region LevelComlpetion
    private List<GameObject> totems = new List<GameObject>();

    public void AddTotem(GameObject totem)
    {
        totems.Add(totem);
    }

    public void TotemDestroyed(GameObject totem)
    {
        totems.Remove(totem);

        if (totems.Count == 0)
            LevelCompleted();
    }

    private void LevelCompleted()
    {
        //Level won
        Debug.Log("NICE!!!!!!!!!!!!!!!!!");
    }
    #endregion

    #region SceneSwitch

    public void LeaveLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    #endregion
}
