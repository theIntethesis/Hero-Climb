using Godot;
using System;
using System.Collections.Generic;

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
	[Export]
	public float ClimbSpeed = 100f;
	public enum ClassType
	{
		Fighter = 1, Rogue = 2, Wizard = 3
	}
	[Export]
	public ClassType Class = 0;
	[Export]
	public int Damage = 50;

	[Signal]
	public delegate void PlayerDeathEventHandler();

	[Signal]
	public delegate void AttackingEventHandler();

	[Signal]
	public delegate void PlayerHealthChangeEventHandler(int change);

	[Signal]
	public delegate void ShutUpAndTakeMyMoneyEventHandler();

	[Signal]
	public delegate void KaChingEventHandler();

	[Signal]
	public delegate void PlayerMaxHealthChangeEventHandler(int change);

	public int MaxHealth = 100;
	protected int Health = 100;
	protected bool attackCooldown = false;

	protected bool IsMovementLocked = false;

	protected AnimatedSprite2D sprites;
	protected PlayerSoundController SoundController = null;
	protected Timer iFrames = new();
	#region Get / Set Methods
	public int getHealth() { return Health; }
	public int affectHealth(int amount)
	{
		if (Health + amount > MaxHealth)
			amount = MaxHealth - Health;

		EmitSignal(SignalName.PlayerHealthChange, amount);
		Health += amount;
		if (Health <= 0) OnPlayerDeath();
		else if (amount < 0) startIFrames();
		return Health;
	}
	public void SetClass(Controller.ClassType type) { Class = type; }
	#endregion
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor() && !PlayerGlobal.isClimbing)
		{
			var grav = GetGravity();
			velocity += grav * (float)delta;
			velocity = velocity.Clamp(-grav, grav);
		}

		// Handle climb. Only works if Controller is a Rogue, as that's the only ClassType that collides with pipes.
		if (Input.IsActionPressed("move_up") && PlayerGlobal.isClimbing)
		{
			velocity += new Vector2(0, -ClimbSpeed * (float)delta);
			//GD.Print(velocity);
		}
		else if (Input.IsActionPressed("move_down") && PlayerGlobal.isClimbing)
		{
			velocity += new Vector2(0, ClimbSpeed * (float)delta);
			//GD.Print(velocity);
		}
		else if (PlayerGlobal.isClimbing && !Input.IsActionPressed("move_down") && !Input.IsActionPressed("move_up") && !Input.IsActionPressed("jump"))
		{
			velocity = Vector2.Zero;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && (IsOnFloor() || PlayerGlobal.isClimbing) && !IsMovementLocked)
		{
			SoundController.Play("Jump");
			velocity.Y += JumpVelocity;
		}

		if (Math.Abs(Velocity.X) > Math.Abs(Speed))
		{
			if (IsOnFloor())
			{
				velocity.X = (float)Mathf.MoveToward(Velocity.X, horizonalMovement().X, 50);
			}
			else
				velocity.X = Velocity.X;
		}
		else
		{
			var walkingSpeed = horizonalMovement().X;
			velocity.X = walkingSpeed;
		}

		if (Input.IsActionJustPressed("ability") && !IsMovementLocked)
		{
			velocity += Ability();
			velocity = velocity.Clamp(new Vector2(-700, -980), new Vector2(700, 980));
		}

		Velocity = velocity;
		MoveAndSlide();

		if (!PlayerGlobal.isAttacking) Animation();

	}
	private void OnPlayerDeath()
	{
		sprites.Offset = getSpriteOffset("death");
		IsMovementLocked = true;
		sprites.Play("death");
	}
	private void CollideWithEnemy(Node2D b)
	{
		if (b.Name == "Player" || b is Attack) return;
		if(b is BaseEnemy)
		{
			var body = b as BaseEnemy;
			uint layer3 = body.CollisionLayer & 0b_0100;
			if (layer3 > 0)
			{
				affectHealth(-body.Damage);
			}
		}
		else if (b is Arrow)
		{
			var body = b as Arrow;
			uint layer3 = body.CollisionLayer & 0b_0100;
			if (layer3 > 0)
			{
				affectHealth(-body.Damage);
			}
		}
		else if (b.Name == "RisingLava")
		{
			affectHealth(-Health);
		}
	}
	private void startIFrames()
	{
		//sprites.Play("Hurt");
		SoundController.Play("Damaged");
		(FindChild("HitboxShape") as CollisionShape2D).SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
		iFrames.Start();
	}
	private void stopIFrames()
	{
		(FindChild("HitboxShape") as CollisionShape2D).SetDeferred(CollisionShape2D.PropertyName.Disabled, false);
	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("jump") && CanJump())
		{
			sprites.Offset = getSpriteOffset("jump");
			sprites.Play("jump");
		}
		if (@event.IsActionPressed("attack") && CanAttack())
		{
			Attack();
		}
		if(@event.IsActionPressed("interact") && PlayerGlobal.InShopArea)
		{
			EmitSignal(SignalName.ShutUpAndTakeMyMoney);
		}
	}
	protected Vector2 horizonalMovement()
	{
		Vector2 velocity = new();
		var inputStr = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		if (inputStr != 0)
		{
			SoundController.Play("Walking");
			if (!IsOnFloor())
			{
				SoundController.Stop("Walking");
			}
			velocity.X = inputStr * Speed;
		}
		else
		{
			SoundController.Stop("Walking");
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
		if (Input.IsActionPressed("move_left") && (IsOnFloor() || PlayerGlobal.isClimbing) && !PlayerGlobal.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("move_left");
			sprites.FlipH = true;
			sprites.Play("run");
		}
		else if (Input.IsActionPressed("move_right") && (IsOnFloor() || PlayerGlobal.isClimbing) && !PlayerGlobal.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("move_right");
			sprites.FlipH = false;
			sprites.Play("run");
		}
		else if ((IsOnFloor() || PlayerGlobal.isClimbing) && !PlayerGlobal.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("idle");
			sprites.Play("idle");
		}
	}
	protected void _on_sprites_animation_finished()
	{
		if (PlayerGlobal.isAttacking)
		{
			attackCooldown = false;
			PlayerGlobal.isAttacking = false;

			GetNode("Attack")?.QueueFree();
		}
		if(Health <= 0)
		{
			EmitSignal(SignalName.PlayerDeath);
		}
		OnAnimationEnd();
	}
	private bool CanAttack()
	{
		return !attackCooldown && !IsMovementLocked;
	}
	private bool CanJump()
	{
		return  (IsOnFloor() || PlayerGlobal.isClimbing) && !IsMovementLocked;
	}
	protected virtual void Attack()
	{
		SoundController.Play("Attack");
		Area2D Attack;
		attackCooldown = true;
		PlayerGlobal.isAttacking = true;
		sprites.Offset = getSpriteOffset("attack");
		sprites.Play("attack");
		Attack = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/attack.tscn").Instantiate() as Attack;
		Attack.Position = sprites.FlipH ? new Vector2(-20, 0) : new Vector2(20, 0);
		AddChild(Attack);
	}
	protected virtual Vector2 Ability()
	{
		return Vector2.Zero;
	}
	protected virtual void OnAnimationEnd()
	{

	}
	public Controller()
	{
		iFrames.OneShot = true;
		iFrames.WaitTime = 1.5;
		AddChild(iFrames);
		iFrames.Connect(Timer.SignalName.Timeout, Callable.From(stopIFrames));
	}
	protected virtual void SetupClassScript()
	{
		GD.Print(Class);
		if (Class != 0)
		{
			SoundController.SetHero(Class);
		}
		else
		{
			GD.PrintErr("Type Not Set");
			throw new TypeUnloadedException();
		}
	}
	public override void _Ready()
	{
		SoundController = GetNode("PlayerSoundController") as PlayerSoundController;
		SetupClassScript();
	}
	public override void _Process(double delta)
	{
		if ((Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right")) && IsOnFloor())
		{
		}
		else
		{
		}
	}
}
