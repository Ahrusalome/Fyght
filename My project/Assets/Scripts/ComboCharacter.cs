using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine meleeStateMachine;
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)  && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState)) {
            meleeStateMachine.SetNextState(new MeleeComboStart());
        }
    }
}
