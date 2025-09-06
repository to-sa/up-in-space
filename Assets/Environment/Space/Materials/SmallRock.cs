using Assets.Player;
using Godot;
using System;

[GlobalClass]
public partial class SmallRock : Area2D
{
    private Player _player;
    private AudioStreamPlayer2D _pickUpSound;

    public override void _Ready()
    {
        _player = (Player)GetTree().GetFirstNodeInGroup("astronaut");
        _pickUpSound = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");

        if (_player == null)
        {
            GD.PushError("Player node not found.");
        }

        BodyEntered += OnPlayerBodyEntered;
        _pickUpSound.Finished += OnSoundFinished;
    }

    public override void _Process(double delta)
    {
        Rotate(0.5f * (float)delta);
        Position += Position.DirectionTo(_player.GlobalPosition) * 80f * (float)delta;
    }

    private void OnPlayerBodyEntered(Node2D body)
    {
        if (body is not Player player) return;
        _pickUpSound.Play();
        Hide();
    }

    private void OnSoundFinished()
    {
        QueueFree();
    }
}
