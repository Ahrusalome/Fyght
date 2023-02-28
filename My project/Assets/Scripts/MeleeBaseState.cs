using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    public float duration;
    protected int attackIndex;
    protected Animator animator;
    protected bool shouldCombo;
    public override void OnEnter(StateMachine _stateMachine) {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.W)) {
            shouldCombo = true;
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
