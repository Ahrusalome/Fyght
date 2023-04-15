using UnityEngine;

public abstract class State
{
    protected float time {get; set;}
    protected float ResetTime = 0.8f;
    protected float lastHitTime;

    public StateMachine stateMachine;

    public virtual void OnEnter(StateMachine _stateMachine) {
        stateMachine = _stateMachine;
    }
    public virtual void OnUpdate() {
        time += Time.deltaTime;
    }
    public virtual void OnExit() {

    }
    protected T GetComponent<T>() where T : Component {
         return stateMachine.GetComponent<T>(); 
        }
}
