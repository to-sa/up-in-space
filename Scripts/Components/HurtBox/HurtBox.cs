using Environment.Space;
using Godot;
using Scripts.Components.HealthComponent;
using Scripts.Components.HitBox;
using System;

[GlobalClass]
public partial class HurtBox : Area2D
{
	[Export] private HealthComponent HealthComponent { get; set; }
	private Node2D _parent;

	public override void _Ready()
	{
		_parent = GetParent<Asteroid>();
		if (_parent == null)
		{
			GD.PushError("The hitbox is missing a parent node.");
			return;
		}

		if (HealthComponent == null)
		{
			GD.PushError("This entity does not have a health component.");
			return;
		}

		AreaEntered += OnHitBoxEntered;
	}

	private void OnHitBoxEntered(Area2D area)
	{
		if (area is not HitBox hitBox) return;

		if (_parent is Asteroid && hitBox.Tool == HitBox.ToolType.Pickaxe)
		{
			var _parentAsteroid = (Asteroid)_parent;
			_parent.CallDeferred(nameof(_parentAsteroid.SpawnSmallRocks));
			HealthComponent.TakeDamage(hitBox.ToolStats.Attack);
		}

	}
}
