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

    public void Attack()
    {
        int randomNum = Random.Range(1,attackAnimCount+1);

        switch (randomNum)
        {
            case 1:
                anim.CrossFade("Armature|Attack1", 0.1f, 0);
                break;
            case 2:
                anim.CrossFade("Armature|Attack2", 0.1f, 0);
                break;
            case 3:
                anim.CrossFade("Armature|Attack3", 0.1f, 0);
                break;
        }
    }

    public void AttackAbove()
    {
        anim.CrossFade("Armature|AttackAbove", 0.1f, 0);
    }

    public void Idle()
    {
        anim.CrossFade("Armature|Idle", 0.1f, 0);
    }

    public void Chase()
    {
        anim.CrossFade("Armature|Chase", 0.1f, 0);
    }

    public void Die()
    {
        anim.CrossFade("Armature|Death", 0.1f, 0);
    }

}
