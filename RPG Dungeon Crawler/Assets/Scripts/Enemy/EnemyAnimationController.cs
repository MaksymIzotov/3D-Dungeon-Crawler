using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;

    private float speed;
    private Vector3 lastPos;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.CrossFade("Attack", 0.1f, 0);
    }
    public void Idle()
    {
        anim.CrossFade("Idle", 0.1f, 0);
    }

    public void Chase()
    {
        anim.CrossFade("Chase", 0.1f, 0);
    }

    public void Die()
    {
        anim.CrossFade("Death", 0.1f, 0);
    }

}
