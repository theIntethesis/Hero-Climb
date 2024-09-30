using Godot;
using System;
using System.Reflection.Metadata;
using static Godot.TextServer;

public partial class PlayerController : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	[Export]
	public float JumpVelocity = -400.0f;
	[Export]
	private float attackDelay = 48f;

	private bool attackCooldown = false;
	private float fireballCountdown = 30f;
	private bool fireballsummon = false;

	protected AnimatedSprite2D sprite;
	public bool isAttacking = false;
	public enum CharClass { Fighter, Rogue, Wizard }
	public readonly CharClass charClass = CharClass.Wizard;
	public Controller c;

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
			sprite.Offset = sprite.FlipH ? new Vector2(-10, -10): new Vector2(10, -10);
			sprite.Play("jump");
		}
		if (@event.IsActionPressed("attack") && !attackCooldown)
		{
			attackCooldown = true;
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
	protected void Attack()
	{
		isAttacking = true;
		sprite.Play("attack");
		var angle = GetViewport().GetMousePosition() - GetViewportRect().Size / 2;
		sprite.FlipH = angle.X > 0 ? false : true;
		switch (charClass)
		{
			case CharClass.Wizard:
				sprite.Offset = sprite.FlipH ? new Vector2(-15, -3) : new Vector2(15, -3);
				fireballsummon = true;
				break;
			default:
				throw new Exception("No Class Selected");
		}
	}
	public void _on_sprites_animation_finished(){
		if (isAttacking)
		{
			attackCooldown = false;
			isAttacking = false;
			if (Input.IsActionPressed("attack"))
				Attack();
		}
	}
	protected void Animation()
	{
		if (Input.IsActionPressed("move_left") && IsOnFloor() && !isAttacking)
		{
			sprite.Offset = new Vector2(0, 0);
			sprite.FlipH = true;
			sprite.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && IsOnFloor() && !isAttacking)
		{
			sprite.Offset = new Vector2(0, 0);
			sprite.FlipH = false;
			sprite.Play("run");
		}
		else if (!Input.IsAnythingPressed() && IsOnFloor() && !isAttacking)
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
		switch (charClass)
		{
			case CharClass.Wizard:
				AddChild(GD.Load<PackedScene>("res://[TL1] Ferris/scenes/WizardSprite.tscn").Instantiate() as AnimatedSprite2D);
				break;
			default:
				throw new Exception("No Class Selected");
		}
		sprite = GetNode("Sprites") as AnimatedSprite2D;
		sprite.Position = new Vector2(0, 0);
		sprite.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
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
