using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected float time {get; set;}
    protected float ResetTime = 1f;
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
    protected static void Destroy(UnityEngine.Object obj)
    {
        UnityEngine.Object.Destroy(obj);
    }
    protected T GetComponent<T>() where T : Component {
         return stateMachine.GetComponent<T>(); 
        }
    protected Component GetComponent(System.Type type) {
        return stateMachine.GetComponent(type);
    }
    protected Component GetComponent(string type) {
        return stateMachine.GetComponent(type);
    }
}
