using Godot;
using System;

namespace Inventory.Data;
[GlobalClass]
public partial class ItemData : Resource
{
    [Export] public String Name;

    [Export] public Texture2D Texture;

    [Export] public bool Stackable;

    [Export(PropertyHint.MultilineText)]
    public String ItemDescription { get; set; }
}
