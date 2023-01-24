using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isColliding;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float force;

    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;

    private float damage;

    private float burnDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("DestroyObject", 10);
    }

    public void SetProperties(float _damage, float _burnDamage)
    {
        damage = _damage;
        burnDamage = _burnDamage;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * force * Time.deltaTime);
    }

    private void Update()
    {
        isColliding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) { return; }
        isColliding = true;

        //Do damage
        bool isPlayerHit = false;
        var collidersInRange = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider n in collidersInRange)
        {
            if(n.tag == TAGS.PLAYER_TAG)
            {
                if (isPlayerHit) { continue; }

                n.gameObject.GetComponent<PlayerController>().AddImpact(transform, explosionForce);
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, null);
                isPlayerHit = true;
            }
            else if(n.tag == TAGS.ENEMY_TAG)
            {
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG));

                if(burnDamage > 0)
                {
                    GetComponent<ParticlesController>().SpawnBurnParticles(n.transform.root, 3f, burnDamage);
                }
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
