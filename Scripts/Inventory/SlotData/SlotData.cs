using Godot;
using System;

namespace Inventory.Data;
[GlobalClass]
public partial class SlotData : Resource
{
    [Export] public ItemData ItemData;

    private int _quantity = 1;

    [Export(PropertyHint.Range, "0, 99,")]
    public int Quantity
    {
        get { return _quantity; }

        set
        {
            _quantity = value;
            if (_quantity > 1 && !ItemData.Stackable)
            {
                _quantity = 1;
                GD.PushError($"{ItemData.Name} is not stackable. Set default value to 1.");
            }
        }
    }
}
