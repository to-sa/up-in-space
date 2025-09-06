using Godot;
using System;
using System.Runtime.InteropServices.Marshalling;

namespace Assets.Tools;
[GlobalClass]
public partial class ToolBase : Node2D
{
    protected AudioStreamPlayer2D HitSound;
    protected AnimatedSprite2D Anim;
    protected CollisionShape2D HitCollision;
    protected Area2D HitBox;

    public override void _Ready()
    {
        HitSound = GetNode<AudioStreamPlayer2D>("HitSound");
        Anim = GetNode<AnimatedSprite2D>("Animation");
        HitCollision = GetNode<CollisionShape2D>("HitBox/CollisionShape2D");
        HitBox = GetNode<Area2D>("HitBox");

        if (HitCollision == null)
        {
            GD.PushError("Missing HitBox component and a collision shape.");
        }

        Anim.AnimationFinished += OnAttackAnimationFinished;
        HitBox.AreaEntered += OnHurtBoxEntered;
    }

    public virtual void AttackAnimation() { }
    public virtual void OnHurtBoxEntered(Area2D area) {} 

    private void OnAttackAnimationFinished()
    {
        HitCollision.Disabled = true;
    }
    
}
