using Godot;
using System;
using System.Dynamic;

namespace Scripts.Components.HitBox;

[GlobalClass]
public partial class HitBox : Area2D
{
    public enum ToolType
    {
        Pickaxe,
        Spade,
        Axe
    }

    [Export] public ToolType Tool;
    [Export] public ToolResource ToolStats;

}
