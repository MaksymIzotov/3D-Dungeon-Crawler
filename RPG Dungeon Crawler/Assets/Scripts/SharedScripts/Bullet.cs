using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private float damage;

    private Vector3 dir;

    private GameObject shooter;

    [SerializeField] private Transform fx;
    [SerializeField] private GameObject destroyFXPrefab;
    private void Start()
    {
        GetDirection();
        Invoke("DestroyObject", 15);
    }

    private void GetDirection()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        fx.LookAt(player);

        dir = player.position - transform.position;
        dir.Normalize();
    }

    public void SetDamage(float _damage, GameObject _shooter) { 
        damage = _damage;
        shooter = _shooter;
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
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
