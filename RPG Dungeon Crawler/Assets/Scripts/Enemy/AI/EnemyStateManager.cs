using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyBaseState AttackingState;
    public EnemyBaseState IdleState;
    public EnemyBaseState ChasingState;

    public Transform attackPoint;

    private void Start()
    {
        currentState = IdleState;

        IdleState.EnterState(this);
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
}
