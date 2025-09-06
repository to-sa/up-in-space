using Godot;
using System;
using System.Transactions;

[GlobalClass]
public abstract partial class State : Node
{
    [Signal]
    public delegate void TransitionedEventHandler(State state, string newStateName);

    public virtual void HandleInput(InputEvent @event) { }
    public virtual void Enter() { } 
    public virtual void Exit() { }
    public virtual void ProcessState(double delta) { }
    public virtual void PhysicsProcessState(double delta) { }
}
