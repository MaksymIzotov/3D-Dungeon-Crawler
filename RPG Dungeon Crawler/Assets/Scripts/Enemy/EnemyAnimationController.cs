using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.Play("Attack");
    }
    public void Idle()
    {
        anim.Play("Idle");
    }
    public void Chase()
    {
        anim.Play("Chase");
    }

    public void Die()
    {
        anim.Play("Death");
    }

}
