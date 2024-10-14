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
	[Export]
	public float ClimbSpeed = 100f;

	public enum ClassType
	{
		Fighter, Rogue, Wizard
	}
	[Export]
	public ClassType Class = ClassType.Wizard;
	[Export]
	public int Damage = 50;

	[Signal]
	public delegate void IsDeadEventHandler();

	[Signal]
	public delegate void AttackingEventHandler();

	[Signal]
	public delegate void InjuryEventHandler();

	protected int Health = 110;
	public int Money = 0;
	protected InjuryEventHandler injury;

	protected bool attackCooldown = false;
	protected float attackCooldownFrames;
	protected bool IsMovementLocked = false;

	protected AnimatedSprite2D sprites;
	public int getHealth() { return Health; }
	public void setClass(Controller.ClassType type) { Class = type; }

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor() || Global.isClimbing)
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle climb. Only works if Controller is a Rogue, as that's the only ClassType that collides with pipes.
		if (Input.IsActionPressed("move_up") && Global.isClimbing)
		{
			velocity += new Vector2(0, -ClimbSpeed * (float)delta);
			GD.Print(velocity);
		}
		else if (Input.IsActionPressed("move_down") && Global.isClimbing)
		{
			velocity += new Vector2(0, ClimbSpeed * (float)delta);
			GD.Print(velocity);
		}
		else if (Global.isClimbing && !Input.IsActionPressed("move_down") && !Input.IsActionPressed("move_up") && !Input.IsActionPressed("jump"))
		{
			velocity = Vector2.Zero;
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
	public void PlayerDeath()
	{
		sprites.Offset = getSpriteOffset("death");
		IsMovementLocked = true;
		sprites.Play("death");
	}
	public void CollideWithEnemy(Area2D body)
	{
		uint layer3 = body.CollisionLayer & 0b_0100;
		if (layer3 > 0)
		{
			/*var enemy = body as Enemy;
			var damage = enemy.damage;*/
			Health -= 20;
			GD.Print($"Collided With Enemy: {body.Name}");
			if(body.Name == "RisingLava")
			{
				Health = 0;
			}

			if (Health <= 0)
			{
				GD.Print("Dead");
				PlayerDeath();
			}
			else
			{
				GD.Print(Health);
				//sprites.Play("Hurt");
				EmitSignal(SignalName.Injury);
				GD.Print("Injury");
			}
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("jump") && (IsOnFloor() || Global.isClimbing) && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("jump");
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

	protected virtual Vector2 getSpriteOffset(string clause)
	{
		return Vector2.Zero;
	}

	protected void Animation()
	{
		if (Input.IsActionPressed("move_left") && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("move_left");
			sprites.FlipH = true;
			(GetNode("Attack Hitbox") as Area2D).Position = new Vector2(-15, 0);
			sprites.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("move_right");
			sprites.FlipH = false;
			(GetNode("Attack Hitbox") as Area2D).Position = new Vector2(15, 0);
			sprites.Play("run");
		}
		else if (!Input.IsAnythingPressed() && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("idle");
			sprites.Play("idle");
		}
	}

	public void _on_sprites_animation_finished()
	{
		if (Global.isAttacking)
		{
			attackCooldown = false;
			Global.isAttacking = false;
			(GetNode("Attack Hitbox/CollisionShape2D") as CollisionShape2D).Disabled = true;
			if (Input.IsActionPressed("attack"))
				Attack();
		}
		if(Health <= 0)
		{
			EmitSignal(SignalName.IsDead);
			GD.Print("IsDead Emitted");
		}
	}

	public virtual void Attack()
	{
		EmitSignal(SignalName.Attacking);
	}
	public virtual void Ability()
	{

	}
	public Controller()
	{
		injury += () => { EmitSignal(SignalName.Injury); };
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
