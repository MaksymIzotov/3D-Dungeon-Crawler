using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStompController : MonoBehaviour
{
    private GameObject player;
    private Vector3 dir;

    [SerializeField] private float speed;

    private bool isDestroying = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
        dir = FindMovingVector();

        Destroy(gameObject, 5);
    }

    private Vector3 FindMovingVector()
    {
        Vector3 _dir = player.transform.position - transform.position;
        _dir.Normalize();
        _dir.y = 0f;
        return _dir;
    }

    private void Update()
    {
        if (isDestroying) { return; }

        Move();
    }

    private void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDestroying) { return; }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(10, null);
            collision.gameObject.GetComponent<PlayerController>().AddImpact(transform,100);
            isDestroying = true;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 2);
        }
    }
}
