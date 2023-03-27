using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class SpecialInput : IInputInteraction
{
    private float duration = 0.2f;
    static SpecialInput() {
        InputSystem.RegisterInteraction<SpecialInput>();
    }
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize(){
    }
    public void Process(ref InputInteractionContext context)
    {
        if(context.timerHasExpired) {
            context.Canceled();
            return;
        }
        switch(context.phase)
        {
            case InputActionPhase.Waiting:
                context.action.ApplyBindingOverride("<Keyboard>/w");
                break;
        }
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

}
