using Godot;
using Inventory.Data;
using Signals;
using System;

namespace UI.Inventory;

[GlobalClass]
public partial class Slot : PanelContainer
{
    [Signal]
    public delegate void SlotClickedEventHandler(int index, int buttonIndex);

    private TextureRect _slotTexture;
    private Label _quantityLabel;

    public override void _Ready()
    {
        _slotTexture = GetNode<TextureRect>("MarginContainer/TextureRect");
        _quantityLabel = GetNode<Label>("QuantityLabel");
        GuiInput += OnGuiInput;
    }

    public void SetSlotData(SlotData slotData)
    {
        var itemData = slotData.ItemData;
        _slotTexture.Texture = itemData.Texture;
        TooltipText = $"{itemData.Name}\n{itemData.ItemDescription}";

        if (slotData.Quantity > 1)
        {
            _quantityLabel.Show();
            _quantityLabel.Text = slotData.Quantity.ToString();
        }
        else
        {
            _quantityLabel.Hide();
        }
    }

    private void OnGuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.IsPressed())
            {
                EmitSignal(SignalName.SlotClicked, GetIndex(), (int)mouseEvent.ButtonIndex);
            }
        }

    }
}
