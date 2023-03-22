using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float force;
    [SerializeField] private float torqueForce;
    [SerializeField] private float radius;

    [SerializeField] private GameObject explosionFXPrefab;

    private float damage;

    private bool isColliding = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Throw();
    }

    public void SetupDamage(float _damage)
    {
        damage = _damage;
    }

    private void Throw()
    {
        Vector3 torque;

        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        torque.x = Random.Range(-torqueForce, torqueForce);
        torque.y = Random.Range(-torqueForce, torqueForce);
        torque.z = Random.Range(-torqueForce, torqueForce);

        rb.AddTorque(torque, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) { return; }
        isColliding = true;
        GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        //Do damage
        bool isPlayerHit = false;
        var collidersInRange = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider n in collidersInRange)
        {
            if (n.tag == TAGS.PLAYER_TAG)
            {
                if (isPlayerHit) { continue; }

                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, null);
                isPlayerHit = true;
            }
            else if (n.tag == TAGS.ENEMY_TAG)
            {
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, player);
            }
        }

        DestroyObject();
    }

    private void DestroyObject()
    {
        Instantiate(explosionFXPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
