using Assets.Player.PlayerStates;
using Godot;
using System;

public partial class InSpace : PlayerState
{
    private const float MaxSpeed = 80f;
    private float acceleration = 50f;

    public override void Enter()
    {
        GD.Print("I'm in space!");
        player.Gravity = 0;
    }

    public override void HandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("action"))
        {
            player.Pickaxe.AttackAnimation();
        }
    }

    public override void PhysicsProcessState(double delta)
    {
        Movement(delta);
    }

    private float AdjustedAcceleration(double delta)
    {
        return acceleration * (float)delta;
    }

    private void Movement(double delta)
    {
        Vector2 velocity = player.Velocity;
        velocity += player.GetMoveInput() * AdjustedAcceleration(delta);
        velocity = velocity.LimitLength(MaxSpeed);
        player.Velocity = velocity;
    }

}
