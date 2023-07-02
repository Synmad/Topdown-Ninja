using UnityEngine;

public class StateManager : MonoBehaviour
{
    State targetState;

    void Update() { RunStateMachine(); }

    void RunStateMachine()
    {
        State nextState = targetState?.RunCurrentState();

        if (nextState != null) NextTargetState(nextState);
    }

    void NextTargetState(State nextState) { targetState = nextState; }
}
