using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody rb;

    public float rotationSpeed;

    public float force;

    public float explosionForce;
    public float radius;

    public float damage;

    public float burnDuration;
    public float burnDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        Invoke("DestroyObject", 10);
    }

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //Do damage

        var collidersInRange = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider n in collidersInRange)
        {
            if(n.tag == "Player")
            {
                n.gameObject.GetComponent<PlayerController>().AddImpact(transform, explosionForce);
            }
            else if(n.tag == "Enemy")
            {
                GetComponent<ParticlesController>().SpawnBurnParticles(n.transform.root, burnDuration, burnDamage);
            }

            n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage);
        }

        DestroyObject();
    }

    private void DestroyObject()
    {
        GetComponent<ParticlesController>().SpawnExplosionParticles();
        Destroy(gameObject);
    }
}
