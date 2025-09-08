using Godot;
using Inventory;
using System;
using Inventory.Data;

namespace Global.Scripts;
[GlobalClass]
public partial class GlobalInventory : Node
{
    public static GlobalInventory Instance { get; private set; }

    [Export]
    public InventoryData Inventory;

    public override void _EnterTree()
    {
        Instance = this;
    }
}
