using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Controller : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	[Export]
	public float JumpVelocity = -400.0f;
	[Export]
	public float attackDelay = 48f;
	[Export]
	public bool AttackFollowMouse = true;
	public enum ClassType
	{
		Fighter, Rogue, Wizard
	}
	[Export]
	public ClassType Class = ClassType.Wizard;

	[Signal]
	public delegate void IsDeadEventHandler();

	protected int Health = 100;
	public int Money = 0;

	protected bool attackCooldown = false;
	protected float attackCooldownFrames;
	protected bool IsMovementLocked = false;

	protected AnimatedSprite2D sprites;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && (IsOnFloor() || Global.isClimbing) && !IsMovementLocked)
		{
			velocity.Y += JumpVelocity;
		}

		velocity.X = horizonalMovement().X;

		Velocity = velocity;
		MoveAndSlide();

		if (!Global.isAttacking) Animation();

	}
	public virtual void PlayerDeath()
	{
		GD.Print("In death method");
		IsMovementLocked = true;
		sprites.Play("death");
	}
	public void CollideWithEnemy(Area2D body)
	{
		if(body.Name != "Fireball")
		{
			/*var enemy = body as Enemy;
			var damage = enemy.damage;*/
			Health -= 20;
			GD.Print(Health);
			GD.Print("Collided With Enemy");
			if (Health <= 0)
			{
				GD.Print("Dead");
				PlayerDeath();
			}
			else
			{
				//sprites.Play("Hurt");
			}
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("jump") && (IsOnFloor() || Global.isClimbing) && !IsMovementLocked)
		{
			sprites.Play("jump");
		}
		if (@event.IsActionPressed("attack") && !attackCooldown && !IsMovementLocked)
		{
			Attack();
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

		return IsMovementLocked ? Vector2.Zero : velocity;
	}

	protected virtual void Animation()
	{
		if (Input.IsActionPressed("move_left") && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking && !IsMovementLocked)
		{
			sprites.FlipH = true;
			sprites.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking && !IsMovementLocked)
		{
			sprites.FlipH = false;
			sprites.Play("run");
		}
		else if (!Input.IsAnythingPressed() && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking && !IsMovementLocked)
		{
			sprites.Play("idle");
		}
	}

	public void _on_sprites_animation_finished()
	{
		if (Global.isAttacking)
		{
			attackCooldown = false;
			Global.isAttacking = false;
			if (Input.IsActionPressed("attack"))
				Attack();
		}
		if(Health <= 0)
		{
			EmitSignal(SignalName.IsDead);
		}
	}

	public virtual void Attack()
	{

	}
	public virtual void Ability()
	{

	}
	public Controller()
	{
		
	}
	public override void _Ready()
	{
		switch (Class)
		{
			case ClassType.Fighter:
				SetScript(GD.Load<Script>("res://[TL1] Ferris/scripts/Fighter.cs"));
				break;
			case ClassType.Rogue:
				SetScript(GD.Load<Script>("res://[TL1] Ferris/scripts/Rogue.cs"));
				break;
			case ClassType.Wizard:
				SetScript(GD.Load<Script>("res://[TL1] Ferris/scripts/Wizard.cs"));
				break;
		}
	}
	public override void _Process(double delta)
	{

	}
}
