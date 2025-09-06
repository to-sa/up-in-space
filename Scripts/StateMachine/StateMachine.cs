using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class StateMachine : Node
{
    [Export] private State _initialState;

    private State _currentState;
    private Dictionary<string, State> _states;

    public override void _Ready()
    {
        _states = [];

        foreach (State child in GetChildren().Cast<State>())
        {
            _states.Add(child.Name.ToString().ToLower(), child);
            child.Transitioned += OnChildTransition;
        }

        if (_initialState != null)
        {
            _currentState = _initialState;
            _initialState.Enter();
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        _currentState?.HandleInput(@event);
    }

    public override void _Process(double delta)
    {
        _currentState?.ProcessState(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        _currentState?.PhysicsProcessState(delta);
    }

    public void OnChildTransition(State state, string newStateName)
    {
        if (state != _currentState)
        {
            return;
        }

        State newState = _states[newStateName.ToLower()];
        if (newState == null)
        {
            return;
        }

        _currentState?.Exit();

        newState.Enter();
        _currentState = newState;
    }
}
