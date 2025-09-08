using Godot;
using Inventory.Data;
using System;

namespace Signals;
public partial class SignalBus : Node
{
    public static SignalBus Instance { get; private set; }

    [Signal]
    public delegate void ToggledInventoryEventHandler();

    [Signal]
    public delegate void InventoryInteractedEventHandler(InventoryData inventory, int index, int button);

    public override void _Ready()
    {
        Instance = this;
    }

}
