using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

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
    public EnemyStatsMultiplier enemyStatsMultiplier;

    public UnityEvent onLevelCompleted;
    public UnityEvent onLevelLost;

    private bool isLevelCompleted = false;
    private float timeToLeave = 10;

    [SerializeField] private GameObject levelExitText;

    [SerializeField] private bool isTutorialLevel = false;

    public void AddTotem(GameObject totem)
    {
        totems.Add(totem);
    }

    public void TotemDestroyed(GameObject totem)
    {
        totems.Remove(totem);

        if (totems.Count == 0)
        {
            if (isTutorialLevel)
            {
                GetComponent<TutorialLevelController>().SetLock(false);
            }
            else
            {
                isLevelCompleted = true;
                levelExitText.SetActive(true);
            }        
        }
    }

    private void LevelCompleted()
    {
        onLevelCompleted.Invoke();
        DifficultyIncrease();
    }
    
    public void DifficultyIncrease()
    {
        enemyStatsMultiplier.healthMult *= 1.1f;
        enemyStatsMultiplier.damageMult *= 1.1f;
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
        AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        if (Time.timeScale == 0) { return; }

        if (Time.timeScale < 0.01f)
        {
            Time.timeScale = 0;
            foreach (AudioSource audioSource in sources)
            {
                audioSource.pitch = Time.timeScale;
            }
        }

        Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.07f);
   
        foreach(AudioSource audioSource in sources)
        {
            audioSource.pitch = Time.timeScale;
        }
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

    private void Update()
    {
        if (!isLevelCompleted) { return; }

        timeToLeave -= Time.deltaTime;
        levelExitText.GetComponent<TMP_Text>().text = "Leaving dungeon in " + timeToLeave.ToString("F0");

        if(timeToLeave <= 0)
        {
            LevelCompleted();
            isLevelCompleted = false;
        }
    }
}
