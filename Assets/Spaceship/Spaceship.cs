using Godot;
using System;

namespace Assets.Spaceship;
[GlobalClass]
public partial class Spaceship : Node2D
{
    [Export] private float _rotationSpeed = 0.05f;

    public override void _Process(double delta)
    {
        Rotate(_rotationSpeed * (float)delta);
    }
}
