using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    #region Singleton Init
    public static EnemyAnimationController Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.Play("Attack");
    }

}
