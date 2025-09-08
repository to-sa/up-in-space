using Global.Scripts;
using Godot;
using Inventory.Data;
using Signals;
using System;

namespace UI.Inventory;

public partial class InventoryUI : PanelContainer
{

    const int MaxInventoryColumns = 4;

    PackedScene Slot = GD.Load<PackedScene>("res://Scripts/Inventory/SlotData/Slot.tscn");

    private GridContainer _itemGrid;

    public override void _Ready()
    {
        _itemGrid = GetNode<GridContainer>("%ItemGrid");
        _itemGrid.Columns = MaxInventoryColumns;

        PopulateInventoryGrid(GlobalInventory.Instance.Inventory);
    }

    private void PopulateInventoryGrid(InventoryData inventory)
    {
        foreach (Node child in _itemGrid.GetChildren())
        {
            child.QueueFree();
        }

        foreach (SlotData slotData in inventory.SlotDatas)
        {
            var slot = (Slot)Slot.Instantiate();
            _itemGrid.AddChild(slot);

            slot.SlotClicked += inventory.OnSlotClicked;

            if (slotData != null)
            {
                slot.SetSlotData(slotData);
            }

        }
    }
}
