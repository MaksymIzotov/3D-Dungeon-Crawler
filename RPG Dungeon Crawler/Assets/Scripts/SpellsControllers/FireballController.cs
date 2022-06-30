using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody rb;

    public float force;

    public float explosionForce;
    public float radius;

    public float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        Invoke("DestroyObject", 10);
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

            n.GetComponent<HealthController>()?.TakeDamage(damage);
        }

        DestroyObject();
    }

    private void DestroyObject()
    {
        GetComponent<ParticlesController>().SpawnParticles();
        Destroy(gameObject);
    }
}
