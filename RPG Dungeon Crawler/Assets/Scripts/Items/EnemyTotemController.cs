using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTotemController : MonoBehaviour, IInteractable
{
    [SerializeField] private string info;

    List<Transform> spawners = new List<Transform>();
    [SerializeField] private EnemiesSpawnSettings settings;

    [SerializeField] private GameObject FX;

    private int enemySpawn;
    private int enemyKilled;

    private Animator anim;

    private void Start()
    {
        enemySpawn = 0;
        enemyKilled = 0;

        anim = GetComponent<Animator>();

        LevelManager.Instance.AddTotem(gameObject);
    }
    public string GetInteractedInfo()
    {
        return info;
    }

    public void Interact()
    {
        GetAllSpawners();

        gameObject.tag = "NonInteractable";
        StartCoroutine(Spawn());
    }

    private void OnEnemyKilled()
    {
        enemyKilled++;

        if (enemyKilled >= settings.enemiesAmount)
            StartDestroyTotem();
    }

    private void StartDestroyTotem()
    {
        //Effects
        Instantiate(FX, transform.position, Quaternion.identity);
        anim.Play("Destroying");
    }

    public void Destruction()
    {
        LevelManager.Instance.TotemDestroyed(gameObject);
        Destroy(gameObject);
    }

    IEnumerator Spawn()
    {
        while (enemySpawn < settings.enemiesAmount)
        {
            GameObject enemy = Instantiate(settings.enemies[Random.Range(0, settings.enemies.Length)], spawners[Random.Range(0, spawners.Count)].position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthController>().onDeath.AddListener(OnEnemyKilled);

            enemySpawn++;
            float delay = Random.Range(settings.minDelay, settings.maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }
    private void GetAllSpawners()
    {
        Transform[] children = transform.parent.GetComponentsInChildren<Transform>();

        foreach(Transform child in children)
        {
            if (child.CompareTag("Spawner"))
                spawners.Add(child);
        }
    }
}
