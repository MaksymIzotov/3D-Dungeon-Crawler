using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    private float damage;

    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;

    [SerializeField] private GameObject destroyFXPrefab;

    private Quaternion lookRotation;
    private Transform target;
    private void Start()
    {
        Invoke("DestroyObject", 15);
    }

    public void Setup(float _damage)
    {
        damage = _damage;
        target = FindClosestEnemy();
    }

    private void Update()
    {
        if (target == null)
        {
            target = FindClosestEnemy();
            if (target == null)
                DestroyObject();
        }
            

        MoveProjectile();
    }

    private void MoveProjectile()
    {
        lookRotation = Quaternion.LookRotation((target.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotSpeed * Time.deltaTime);

        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }

    private Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(TAGS.MIDDLEPOINT_TAG);

        if (enemies.Length == 0)
            return null;
        if (enemies.Length == 1)
            return enemies[0].transform;

        GameObject closestEnemy = enemies[0];
        for (int i = 1; i < enemies.Length; i++)
        {
            if(Vector3.Distance(transform.position,closestEnemy.transform.position) > Vector3.Distance(transform.position, enemies[i].transform.position))
            {
                closestEnemy = enemies[i];
            }
        }

        return closestEnemy.transform;
    }

    private void DestroyObject()
    {
        if (destroyFXPrefab != null)
            Instantiate(destroyFXPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(TAGS.ENEMY_TAG))
            collision.transform.root.GetComponent<IDamagable>().TakeDamage(damage, null);

        if (collision.gameObject.CompareTag(TAGS.PLAYER_TAG))
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(damage, null);

        DestroyObject();
    }
}
