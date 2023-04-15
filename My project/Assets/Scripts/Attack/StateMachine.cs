using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState {get; private set;}
    public State mainStateType = new IdleCombatState();
    private State nextState;
    void Update()
    {
        if (nextState != null) {
            SetState(nextState);
        }
        if (CurrentState != null) {
            CurrentState.OnUpdate();
        }
    }

    private void SetState(State _newState) {
        nextState = null;
        if (CurrentState != null) {
            CurrentState.OnExit();
        }
        CurrentState = _newState;
        CurrentState.OnEnter(this);
    }

    public void SetNextState(State _newState) {
        if (_newState != null) {
            nextState = _newState;
        }
    }
    public void SetNextStateToMain() {
        nextState = mainStateType;
    }
     private void Awake()
    {
        SetNextStateToMain();
    }

}
