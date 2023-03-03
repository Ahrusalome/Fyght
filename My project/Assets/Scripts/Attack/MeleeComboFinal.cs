using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeComboFinal : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        attackIndex = 3;
        duration = 0.5f;
        animator.SetTrigger("SDAttack" + attackIndex);
        lastHitTime = Time.time + duration;
    }
}
