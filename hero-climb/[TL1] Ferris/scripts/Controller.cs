using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayerController;

public partial class Controller : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	[Export]
	public float JumpVelocity = -400.0f;
	[Export]
	public float attackDelay = 48f;
	[Export]
	public bool AttackFollowMouse = false;
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


	protected int Health = 100;
	public int Money = 0;
	protected InjuryEventHandler injury;

	protected bool attackCooldown = false;
	protected float attackCooldownFrames;

	protected AnimatedSprite2D sprites;
	public int getHealth() { return Health; }

	public void SetClass(Controller.ClassType cType)
	{
		Class = cType;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
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
		if (@event.IsActionPressed("jump") && (IsOnFloor() || Global.isClimbing))
		{
			sprites.Play("jump");
		}
		if (@event.IsActionPressed("attack") && !attackCooldown)
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

		return velocity;
	}

	protected virtual void Animation()
	{
		if (Input.IsActionPressed("move_left") && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking)
		{
			sprites.FlipH = true;
			(GetNode("Attack Hitbox/CollisionShape2D") as CollisionShape2D).Position = new Vector2(0, -15);
			sprites.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking)
		{
			sprites.FlipH = false;
			(GetNode("Attack Hitbox/CollisionShape2D") as CollisionShape2D).Position = new Vector2(0, 15);
			sprites.Play("run");
		}
		else if (!Input.IsAnythingPressed() && (IsOnFloor() || Global.isClimbing) && !Global.isAttacking)
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
		GD.PushWarning($"In Constructor: {Class}");
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
		GD.PushWarning($"End of constructor");
	}
	public override void _Process(double delta)
	{

	}
}
