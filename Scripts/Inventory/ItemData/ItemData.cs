using Godot;
using System;

[GlobalClass]
public partial class ItemData : Resource
{
    [Export] private String name;

    [Export] private AtlasTexture texture;

    [Export(PropertyHint.MultilineText)]
    private String ToolDir { get; set; }
}
