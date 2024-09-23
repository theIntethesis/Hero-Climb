using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerController : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	[Export]
	public float JumpVelocity = -400.0f;

	protected AnimatedSprite2D sprite;
	protected bool isAttacking = false;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		velocity.X = horizonalMovement().X;

		Velocity = velocity;
		MoveAndSlide();

		if (!isAttacking) Animation();

	}
	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("jump") && IsOnFloor())
		{
			sprite.Offset = new Vector2(4, -6);
			sprite.Play("jump");
		}
		if (@event.IsActionPressed("attack"))
		{
			isAttacking = true;
			sprite.Play("attack");
		}
	}
	public void _on_sprites_animation_finished(){
		
	}
	protected void Animation()
	{
		if (Input.IsActionPressed("move_left") && IsOnFloor())
		{
			sprite.Offset = new Vector2(0, 0);
			sprite.FlipH = true;
			sprite.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && IsOnFloor())
		{
			sprite.Offset = new Vector2(0, 0);
			sprite.FlipH = false;
			sprite.Play("run");
		}
		else if (!Input.IsAnythingPressed() && IsOnFloor())
		{
			sprite.Offset = new Vector2(0, 0);
			sprite.Play("idle");
		}
	}
	protected Vector2 horizonalMovement()
	{
		Vector2 velocity = new();
		var inputStr = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		if (inputStr != 0)
		{
			velocity.X = inputStr * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		return velocity;
	}
	public override void _Ready()
	{
		sprite = GetNode("Sprites") as AnimatedSprite2D;
	}
	public override void _Process(double delta)
	{
		Animation();
	}
}
