using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float force;

    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;

    private float damage;

    private float burnDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        Invoke("DestroyObject", 10);
    }

    public void SetProperties(float _damage, float _burnDamage)
    {
        damage = _damage;
        burnDamage = _burnDamage;
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
            if(n.tag == TAGS.PLAYER_TAG)
            {
                n.gameObject.GetComponent<PlayerController>().AddImpact(transform, explosionForce);
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, null);


                Debug.Log("Damaging " + n.gameObject.name);
            }
            else if(n.tag == TAGS.ENEMY_TAG)
            {
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG));

                if(burnDamage > 0)
                {
                    GetComponent<ParticlesController>().SpawnBurnParticles(n.transform.root, 3f, burnDamage);
                }

                Debug.Log("Damaging " + n.gameObject.name);
            }
        }

        DestroyObject();
    }

    private void DestroyObject()
    {
        GetComponent<ParticlesController>().SpawnExplosionParticles();
        Destroy(gameObject);
    }
}
