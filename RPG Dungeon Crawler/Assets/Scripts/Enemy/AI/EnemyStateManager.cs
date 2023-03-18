using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    [Space(10)]
    [Header("Enemy states")]

    public EnemyBaseState SpawnState;
    public EnemyBaseState IdleState;
    public EnemyBaseState ChasingState;
    public EnemyBaseState AttackingState;
    public EnemyBaseState StunState;
    public EnemyBaseState GroundStompState;

    [Space(10)]
    [Header("Boss states")]

    public EnemyBaseState MovingState;
    public EnemyBaseState SpawnEnemiesState;

    public GameObject attackPoint;
    public GameObject attackPointAbove;
    public Transform eyes;

    private void Start()
    {
        currentState = SpawnState;

        SpawnState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public EnemyBaseState GetCurrentState()
    {
        return currentState;
    }
}
