using Godot;
using Inventory.Data;
using Signals;
using System;

namespace UI.Inventory;

public partial class InventoryInterface : Control
{
    private Control _playerInventory;

    public override void _Ready()
    {
        _playerInventory = GetNode<Control>("Inventory");
        SignalBus.Instance.ToggledInventory += OnToggledInventory;
        SignalBus.Instance.InventoryInteracted += OnInventoryInteracted;
    }

    private void OnToggledInventory()
    {
        _playerInventory.Visible = !_playerInventory.Visible;
    }

    private void OnInventoryInteracted(InventoryData inventory, int index, int button)
    {
        GD.Print($"{inventory}, {index}, {button}");
    }

}
