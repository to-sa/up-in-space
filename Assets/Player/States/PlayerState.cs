using Assets.Player;
using Godot;
using System.Diagnostics;

namespace Assets.Player.PlayerStates;
[GlobalClass]
public abstract partial class PlayerState : State
{
    protected Player player;

    public override void _Ready()
    {
        player = GetOwner<Player>();
        Debug.Assert(player != null, "The player needs to be a Player node.");
    }
}
