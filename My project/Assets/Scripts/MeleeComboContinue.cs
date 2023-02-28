using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeComboContinue : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        attackIndex = 2;
        duration = 1f;
        animator.SetTrigger("SDAttack" + attackIndex);
        lastHitTime = Time.time + duration;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (time >=duration) {
            if (shouldCombo) {
                stateMachine.SetNextState(new MeleeComboFinal());
            }
        }
        if (Time.time - lastHitTime >= ResetTime) {
            stateMachine.SetNextStateToMain();
        }
    }
}
