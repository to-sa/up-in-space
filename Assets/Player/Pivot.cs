using Godot;
using System;

namespace Assets.Player;
public partial class Pivot : Node2D
{
    public override void _Process(double delta)
    {
        LookAt(GetGlobalMousePosition());
    }
}
