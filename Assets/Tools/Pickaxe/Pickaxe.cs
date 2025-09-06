using Environment.Space;
using Godot;
using System;

namespace Assets.Tools;
[GlobalClass]
public partial class Pickaxe : ToolBase
{
    public override void AttackAnimation()
    {
        Anim.Play("attack");
        HitCollision.Disabled = false;
    }

    public override void OnHurtBoxEntered(Area2D area)
    {
        if (area is not HurtBox hurtBox) return;

        if (hurtBox.Owner is Asteroid)
        {
            HitSound.Play();
        }
    }
}
