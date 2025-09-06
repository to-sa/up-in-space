using Godot;
using System;

namespace Assets.Player;

[GlobalClass]
public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 50;
    [Export] public float Gravity = 1000;
    [Export] public float JumpForce = 50;

    public Pickaxe Pickaxe;

    public override void _Ready()
    {
        AddToGroup("astronaut");
        Pickaxe = GetNode<Pickaxe>("%Pickaxe");

        if (Pickaxe == null)
        {
            GD.PushError("Missing tool");
        }
    }

    public override void _Process(double delta)
    {
        LimitPlayerPos();
    }


    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity.Y += Gravity * (float)delta;
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    public Vector2 GetMoveInput()
    {
        return Input.GetVector("left", "right", "up", "down");
    }

    private void LimitPlayerPos()
    {
        float screenLeft = GetViewport().GetCamera2D().LimitLeft;
        float screenRight = GetViewport().GetCamera2D().LimitRight;
        float screenTop = GetViewport().GetCamera2D().LimitTop;
        float screenBottom = GetViewport().GetCamera2D().LimitBottom;

        Vector2 globalPosition = GlobalPosition;

        globalPosition.X = Math.Clamp(globalPosition.X, screenLeft, screenRight);
        globalPosition.Y = Math.Clamp(globalPosition.Y, screenTop + 25, screenBottom);

        GlobalPosition = globalPosition;
    }



}
