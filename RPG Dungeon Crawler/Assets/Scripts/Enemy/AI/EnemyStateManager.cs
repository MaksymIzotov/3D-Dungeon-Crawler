using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyBaseState IdleState;
    public EnemyBaseState ChasingState;
    public EnemyBaseState AttackingState;
    public EnemyBaseState StunState;
    public EnemyBaseState GroundStompState;

    public Transform attackPoint;
    public Transform eyes;

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

    public EnemyBaseState GetCurrentState()
    {
        return currentState;
    }
}
