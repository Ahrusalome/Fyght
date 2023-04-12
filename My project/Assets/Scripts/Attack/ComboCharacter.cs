using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine meleeStateMachine;
    private IdleCombatState idle = new IdleCombatState();
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        meleeStateMachine = GetComponent<StateMachine>();
    }
    void OnSDAttack() {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("IsAttacked")){
            if (meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState)) {
                meleeStateMachine.SetNextState(new MeleeComboStart());
            }
            if (meleeStateMachine.CurrentState.GetType() == typeof(MeleeComboStart)) {
                meleeStateMachine.SetNextState(new MeleeComboContinue());
            }
            if (meleeStateMachine.CurrentState.GetType() == typeof(MeleeComboContinue)) {
                meleeStateMachine.SetNextState(new MeleeComboFinal());
            }
        }
    }
}
