using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProjectileController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float minRotSpeed = 1;
    [SerializeField] private float maxRotSpeed = 1;
    private float damage;

    private GameObject shooter;
    private float speed;
    private float rotSpeed;

    [SerializeField] private GameObject destroyFXPrefab;

    private Transform player;
    private Quaternion lookRotation;
    private void Start()
    {
        Setup();
        Invoke("DestroyObject", 15);
    }

    private void Setup()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG).transform;
    }

    public void SetDamage(float _damage, GameObject _shooter)
    {
        damage = _damage;
        shooter = _shooter;
    }

    private void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        lookRotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotSpeed * Time.deltaTime);

        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }

    private void DestroyObject()
    {
        if (destroyFXPrefab != null)
            Instantiate(destroyFXPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(damage, shooter);

        DestroyObject();
    }
}
