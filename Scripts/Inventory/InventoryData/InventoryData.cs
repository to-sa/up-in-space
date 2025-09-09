using Godot;
using System;
using Godot.Collections;
using Signals;

namespace Inventory.Data;

[GlobalClass]
public partial class InventoryData : Resource
{

    [Signal]
    public delegate void InventoryUpdatedEventHandler(InventoryData inventory);

    [Export]
    public Array<SlotData> SlotDatas;

    public void OnSlotClicked(int index, int buttonIndex)
    {
        SignalBus.Instance.EmitSignal("InventoryInteracted", this, index, buttonIndex);
    }

    public SlotData GrabSlotData(int index)
    {
        var slotData = SlotDatas[index];

        if (slotData != null)
        {
            SlotDatas[index] = null;
            EmitSignal(SignalName.InventoryUpdated, this);
            return slotData;
        }
        else
        {
            return null;
        }
    }

    public SlotData DropSlotData(SlotData grabbedSlotData, int index)
    {
        var slotData = SlotDatas[index];

        SlotDatas[index] = grabbedSlotData;
        EmitSignal(SignalName.InventoryUpdated, this);
        
        if (slotData != null)
        {
            return slotData;
        }
        else
        {
            return null;
        }
    }
}