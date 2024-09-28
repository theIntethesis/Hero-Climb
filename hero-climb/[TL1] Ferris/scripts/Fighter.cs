using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Fighter : Controller
{
	public Fighter()
	{
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/FighterSprite.tscn").Instantiate() as AnimatedSprite2D;
		attackCooldownFrames = 48f;
	}
	public override void Attack()
	{
		attackCooldown = true;
		Global.isAttacking = true;
		sprites.Play("attack");
	}
	protected override void Animation()
	{
		if (Input.IsActionPressed("move_left") && IsOnFloor() && !Global.isAttacking)
		{
			sprites.FlipH = true;
			sprites.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && IsOnFloor() && !Global.isAttacking)
		{
			sprites.FlipH = false;
			sprites.Play("run");
		}
		else if (!Input.IsAnythingPressed() && IsOnFloor() && !Global.isAttacking)
		{
			sprites.Play("idle");
			sprites.Offset = new Vector2(0, -13);
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
		base._Process(delta);
	}
}
