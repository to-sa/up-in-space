using Godot;
using System;
using Godot.Collections;
using Signals;

namespace Inventory.Data;

[GlobalClass]
public partial class InventoryData : Resource
{
    [Export]
    public Array<SlotData> SlotDatas;

    public void OnSlotClicked(int index, int buttonIndex)
    {
        SignalBus.Instance.EmitSignal("InventoryInteracted", this, index, buttonIndex);
    }
}
