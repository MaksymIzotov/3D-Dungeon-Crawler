using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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

    public UnityEvent onLevelCompleted;
    public UnityEvent onLevelLost;

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
        onLevelCompleted.Invoke();
    }
    #endregion

    #region SceneSwitch

    public void LeaveLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    #endregion

    #region TimeSlow

    private bool isSlow = false;

    private void TimeSlow()
    {
        if (Time.timeScale == 0) { return; }

        if (Time.timeScale < 0.01f) { Time.timeScale = 0; }

        Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.07f);
    }

    public void StopTime(bool condition)
    {
        isSlow = condition;
    }
    #endregion

    #region Getters

    public List<GameObject> GetCurrentTotems => totems;

    #endregion

    private void FixedUpdate()
    {
        if (!isSlow) { return; }

        TimeSlow();
    }
}
