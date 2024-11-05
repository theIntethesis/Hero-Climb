using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

public partial class Wizard : Controller 
{
	private float fireballCountdown = 30f;
	private bool fireballsummon = false;
	private Timer FireballSummon = new();

	public Wizard()
	{
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/WizardSprite.tscn").Instantiate() as AnimatedSprite2D;
		AddChild(sprites);
		sprites.Position = Vector2.Zero;
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));

        FireballSummon.OneShot = true;
        FireballSummon.WaitTime = .5;
        AddChild(FireballSummon);
        FireballSummon.Connect(Timer.SignalName.Timeout, Callable.From(SummonFireball));
    }
	protected override Vector2 Ability()
	{
		// play arcane words sound
		attackCooldown = true;
		PlayerGlobal.isAttacking = true;
		sprites.Play("fireball");
		var angle = GetViewport().GetMousePosition() - GetViewportRect().Size / 2;
		if(AttackFollowMouse) sprites.FlipH = angle.X > 0 ? false : true;
		sprites.Offset = getSpriteOffset("fireball");
		FireballSummon.Start();
		return Vector2.Zero;
	}

	protected void SummonFireball()
	{
		// Play fireball sound.
		EmitSignal(SignalName.Attacking);
		var fireball = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/fireball.tscn").Instantiate() as Fireball;
		fireball.Position = Position;
		//fireball.Position = sprite.FlipH ? new Vector2(-16, -8) + Position : new Vector2(16, -8) + Position;
		AddSibling(fireball);
		fireball.setVelocity(AttackFollowMouse, sprites.FlipH);
	}

	protected override Vector2 getSpriteOffset(string clause)
	{
		Vector2 Vec = Vector2.Zero;
		switch (clause)
		{
			case "move_left":
				Vec = Vector2.Zero;
				break;
			case "move_right":
				Vec = Vector2.Zero;
				break;
			case "idle":
				Vec = Vector2.Zero;
				break;
			case "death":
				Vec = sprites.FlipH ? new Vector2(-15, -31) : new Vector2(15, -31);
				break;
			case "fireball":
				Vec = sprites.FlipH ? new Vector2(-15, -3) : new Vector2(15, -3);
				break;
			case "jump":
				Vec = sprites.FlipH ? new Vector2(-10, -10) : new Vector2(10, -10);
				break;
			case "attack":
				Vec = Vector2.Zero;
				break;
			default:
				Vec = Vector2.Zero;
				break;
		}
		return Vec;
	}
	public override void _Ready()
	{

	}
	public override void _Process(double delta)
	{
		if (fireballsummon)
		{
			fireballCountdown--;
			if (fireballCountdown <= 0)
			{
				SummonFireball();
				fireballsummon = false;
				fireballCountdown = 30;
			}
		}

		// if (Health <= 0) OnPlayerDeath();
	}
}
