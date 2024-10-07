using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using static PlayerController;

public partial class Rogue : Controller
{
	[Export]
	public float ClimbSpeed = 100f;
	public Rogue()
	{
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/RogueSprite.tscn").Instantiate() as AnimatedSprite2D;
		attackCooldownFrames = 48f;
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor() && !Global.isClimbing)
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle climb.
		if (Input.IsActionPressed("move_up") && Global.isClimbing)
		{
			velocity += new Vector2(0, -ClimbSpeed * (float)delta);
		}
		else if (Input.IsActionPressed("move_down") && Global.isClimbing)
		{
			velocity += new Vector2(0, ClimbSpeed * (float)delta);
		}
		else if (Global.isClimbing && !Input.IsActionPressed("move_down") && !Input.IsActionPressed("move_up"))
		{
			velocity = Vector2.Zero;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && (IsOnFloor() || Global.isClimbing))
		{
			velocity.Y += JumpVelocity;
		}

		velocity.X = horizonalMovement().X;

		Velocity = velocity;
		MoveAndSlide();

		if (!Global.isAttacking) Animation();

	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("jump") && IsOnFloor())
		{
			sprites.Play("jump");
		}
		if (@event.IsActionPressed("attack") && !attackCooldown)
		{
			Attack();
		}
	}

	public override void Attack()
	{
		attackCooldown = true;
		Global.isAttacking = true;
		sprites.Play("attack");
		(GetNode("Attack Hitbox/CollisionShape2D") as CollisionShape2D).Disabled = false;
	}
	protected override void Animation()
	{
		base.Animation();
	}
	public override void PlayerDeath()
	{
		base.PlayerDeath();
	}
	public override void _Ready()
	{

	}
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
