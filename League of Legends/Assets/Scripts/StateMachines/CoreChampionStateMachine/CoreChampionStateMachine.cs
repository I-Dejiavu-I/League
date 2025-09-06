using UnityEngine;

public class CoreChampionStateMachine
{
    public StateManager state { get; private set; }

    public void Initialize (StateManager state)
    {
        this.state = state;
        this.state.Enter();
    }

    public void Change(StateManager state)
    {
        this.state.Exit();
        Initialize(state);
    }
}
