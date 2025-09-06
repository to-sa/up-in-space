using Godot;
using System;

namespace Scripts.Components.HealthComponent;

[GlobalClass]
public partial class HealthComponent : Node2D
{
    [Export] private float Health { get; set; }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Owner.QueueFree();
        }
    }
}
