using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region SingletonInit
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

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

}
