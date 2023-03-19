using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BossLevelController : MonoBehaviour
{
    public static BossLevelController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform bossSpawnpoint;

    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject healthbarParent;

    [SerializeField] private GameObject levelExitText;

    public UnityEvent onLevelCompleted;
    public UnityEvent onLevelFailed;

    private bool isLevelCompleted = false;
    private float timeToLeave = 10f;

    private void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();

        Invoke("SpawnBoss", 5);
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnpoint.position, Quaternion.identity);

        healthbarParent.SetActive(true);
    }

    public void LevelComplpeted()
    {
        isLevelCompleted = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(TAGS.ENEMY_TAG);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<IDamagable>()?.Die();
        }

        healthbarParent.SetActive(false);
        levelExitText.SetActive(true);

        //Drop
    }

    public void UpdateHealthBar(float currentHp, float maxHp)
    {
        healthBar.fillAmount = ExtensionMethods.Remap(currentHp, 0, maxHp, 0, 1);
    }

    private void Update()
    {
        if (!isLevelCompleted) { return; }

        timeToLeave -= Time.deltaTime;
        levelExitText.GetComponent<TMP_Text>().text = "Leaving dungeon in " + timeToLeave.ToString("F0");

        if (timeToLeave <= 0)
        {
            onLevelCompleted.Invoke();
            isLevelCompleted = false;
        }
    }
}
