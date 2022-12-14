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

    private float burnDuration;
    private float burnDamage;

    private bool isUpgraded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        Invoke("DestroyObject", 10);
    }

    public void SetProperties(float _damage)
    {
        damage = _damage;
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
            }
            else if(n.tag == TAGS.ENEMY_TAG)
            {
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG));
            }
        }

        DestroyObject();
    }

    public void Upgrade()
    {
        isUpgraded = true;
    }

    private void DestroyObject()
    {
        GetComponent<ParticlesController>().SpawnExplosionParticles();
        Destroy(gameObject);
    }
}
