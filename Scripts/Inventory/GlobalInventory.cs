using Godot;
using System;

[GlobalClass]
public partial class GlobalInventory : Node
{
    public static GlobalInventory Instance { get; private set; }

    public override void _EnterTree()
    {
        Instance = this;
    }
}
