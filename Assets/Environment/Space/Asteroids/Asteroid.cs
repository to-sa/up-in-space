using Godot;
using System;
using System.Xml.Resolvers;

namespace Environment.Space;
[GlobalClass]
public partial class Asteroid : Sprite2D
{

    PackedScene SmallRock = GD.Load<PackedScene>("res://Assets/Environment/Space/Materials/small_rock.tscn");

    private float _rotationSpeed = 0.1f;
    private float _speed = 25.5f;

    public override void _Process(double delta)
    {
        Rotate(_rotationSpeed * (float)delta);
        Position += Vector2.Left * _speed * (float)delta;

        if (GlobalPosition.X < -520)
        {
            QueueFree();
        }
    }

    public void SpawnSmallRocks()
    {
        var rock = (SmallRock)SmallRock.Instantiate();
        GetTree().CurrentScene.AddChild(rock);
        rock.GlobalPosition = GlobalPosition;
    }

}