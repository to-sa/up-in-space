using Godot;
using Inventory.Data;
using Signals;
using System;
using System.Diagnostics.CodeAnalysis;

namespace UI.Inventory;

public partial class InventoryInterface : Control
{
    private Control _playerInventory;
    private Slot _grabbedSlot;
    private SlotData _grabbedSlotData;
    
    public override void _Ready()
    {
        _playerInventory = GetNode<Control>("Inventory");
        _grabbedSlot = GetNode<Slot>("GrabbedSlot");

        SignalBus.Instance.ToggledInventory += OnToggledInventory;
        SignalBus.Instance.InventoryInteracted += OnInventoryInteracted;
    }

    public override void _Process(double delta)
    {
        if (_grabbedSlot.Visible)
        {
            _grabbedSlot.GlobalPosition = GetGlobalMousePosition() + new Vector2(2.5f, 2.5f);
        }
    }

    private void OnToggledInventory()
    {
        _playerInventory.Visible = !_playerInventory.Visible;
    }

    private void OnInventoryInteracted(InventoryData inventory, int index, int button)
    {
        const int mouseClick = (int)MouseButton.Left;

        switch (_grabbedSlotData, button)
        {
            case (null, mouseClick):
                _grabbedSlotData = inventory.GrabSlotData(index);
                break;
            case (_, mouseClick):
                _grabbedSlotData = inventory.DropSlotData(_grabbedSlotData, index);
                break;
        }

        UpdateGrabbedSlot();
    }

    private void UpdateGrabbedSlot()
    {
        if (_grabbedSlotData != null)
        {
            _grabbedSlot.Show();
            _grabbedSlot.SetSlotData(_grabbedSlotData);
        }
        else
        {
            _grabbedSlot.Hide();
        }
    }
}
