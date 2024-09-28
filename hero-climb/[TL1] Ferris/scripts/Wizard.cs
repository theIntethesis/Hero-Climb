using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using static PlayerController;

public partial class Wizard : Controller 
{
	private float fireballCountdown = 30f;
	private bool fireballsummon = false;

	public Wizard()
	{
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/WizardSprite.tscn").Instantiate() as AnimatedSprite2D;
		attackCooldownFrames = 48f;
	}
	public override void Attack()
	{
		attackCooldown = true;
		Global.isAttacking = true;
		sprites.Play("attack");
		var angle = GetViewport().GetMousePosition() - GetViewportRect().Size / 2;
		sprites.FlipH = angle.X > 0 ? false : true;
		sprites.Offset = sprites.FlipH ? new Vector2(-15, -3) : new Vector2(15, -3);
		fireballsummon = true;
	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("jump") && IsOnFloor())
		{
			sprites.Offset = sprites.FlipH ? new Vector2(-10, -10) : new Vector2(10, -10);
			sprites.Play("jump");
		}
		if (@event.IsActionPressed("attack") && !attackCooldown)
		{
			Attack();
		}
	}
	protected void SummonFireball()
	{
		var fireball = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/fireball.tscn").Instantiate() as Fireball;
		fireball.Position = Position;
		//fireball.Position = sprite.FlipH ? new Vector2(-16, -8) + Position : new Vector2(16, -8) + Position;
		AddSibling(fireball);
		fireball.setVelocity();
		fireballsummon = false;
		fireballCountdown = 30;
	}
	protected override void Animation()
	{
		if (Input.IsActionPressed("move_left") && IsOnFloor() && !Global.isAttacking)
		{
			sprites.Offset = new Vector2(0, 0);
			sprites.FlipH = true;
			sprites.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && IsOnFloor() && !Global.isAttacking)
		{
			sprites.Offset = new Vector2(0, 0);
			sprites.FlipH = false;
			sprites.Play("run");
		}
		else if (!Input.IsAnythingPressed() && IsOnFloor() && !Global.isAttacking)
		{
			sprites.Offset = new Vector2(0, 0);
			sprites.Play("idle");
		}
	}
	public override void _Ready()
	{
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
	}
	public override void _Process(double delta)
	{
		if (fireballsummon)
		{
			fireballCountdown--;
			if (fireballCountdown <= 0)
			{
				SummonFireball();
			}
		}
	}
}
