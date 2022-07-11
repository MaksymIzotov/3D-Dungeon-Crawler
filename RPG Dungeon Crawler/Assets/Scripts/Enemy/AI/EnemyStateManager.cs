using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public DummyAttackingState AttackingState = new DummyAttackingState();
    public DummyIdleState IdleState = new DummyIdleState();
    public DummyChasingState ChasingState = new DummyChasingState();

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
