using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantEnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemiesSpawnSettings settings;

    [SerializeField] private float startDelay = 5;
    [SerializeField] private LayerMask ignoreLayers;

    List<Transform> spawners = new List<Transform>();

    private int enemySpawned;

    private void Start()
    {
        Invoke("DelayedStart", 0.2f);
        Invoke("StartSpawning", startDelay);
    }

    private void DelayedStart()
    {
        spawners = GetAllSpawners();
    }

    private void OnEnemyKilled()
    {
        enemySpawned--;
    }

    private void StartSpawning()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (enemySpawned < settings.enemiesAmount)
            {
                if (GetAllSpawners().Count > 0)
                {
                    spawners.Clear();
                    spawners = GetAllSpawners();
                }

                GameObject enemy = Instantiate(settings.enemies[Random.Range(0, settings.enemies.Length)], spawners[Random.Range(0, spawners.Count)].position, Quaternion.identity);
                enemy.GetComponent<EnemyHealthController>().onDeath.AddListener(OnEnemyKilled);

                enemySpawned++;
            }

            float delay = Random.Range(settings.minDelay, settings.maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    private List<Transform> GetAllSpawners()
    {
        List<Transform> buffer = new List<Transform>();

        Transform player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG).transform;

        RaycastHit hit;

        if (Physics.Raycast(player.position, player.TransformDirection(Vector3.down), out hit, Mathf.Infinity, ~ignoreLayers))
        {
            Transform[] children = hit.transform.parent.GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                if (child.CompareTag(TAGS.SPAWNER_TAG))
                    buffer.Add(child);
            }
        }

        return buffer;
    }
}
