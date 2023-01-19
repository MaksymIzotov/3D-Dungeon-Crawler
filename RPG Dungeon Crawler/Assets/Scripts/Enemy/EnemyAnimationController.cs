using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [Tooltip("Number of attack animation it has")]
    [SerializeField] private int attackAnimCount;

    [SerializeField] private Animator anim;

    private float speed;
    private Vector3 lastPos;
    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        anim.enabled = false;
    }

    public void Attack()
    {
        int randomNum = Random.Range(1,attackAnimCount+1);

        switch (randomNum)
        {
            case 1:
                anim.CrossFade("Attack1", 0.1f, 0);
                break;
            case 2:
                anim.CrossFade("Attack2", 0.1f, 0);
                break;
            case 3:
                anim.CrossFade("Attack3", 0.1f, 0);
                break;
        }
    }

    public void AttackAbove()
    {
        anim.CrossFade("AttackAbove", 0.1f, 0);
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

    public void GroundStomp()
    {
        anim.CrossFade("GroundStomp", 0.1f, 0);
    }

}
