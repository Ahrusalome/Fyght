using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    public float duration;
    protected int attackIndex;
    protected Animator animator;
    public override void OnEnter(StateMachine _stateMachine) {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Time.time - lastHitTime >= ResetTime) {
            stateMachine.SetNextStateToMain();
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
