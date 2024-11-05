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
	public delegate void PlayerDeathEventHandler();

	[Signal]
	public delegate void AttackingEventHandler();

	[Signal]
	public delegate void PlayerHealthChangeEventHandler();

	[Signal]
	public delegate void ShutUpAndTakeMyMoneyEventHandler();

	public int MaxHealth = 100;
	protected int Health = 100;
	protected bool attackCooldown = false;

	protected bool IsMovementLocked = false;

	protected AnimatedSprite2D sprites;
	protected Node SoundController;
	protected Timer iFrames = new();
	public int getHealth() { return Health; }
	public int affectHealth(int amount)
	{
		Health += amount;
		EmitSignal(SignalName.PlayerHealthChange);
		return Health;
	}
	public void SetClass(Controller.ClassType type) { Class = type; }

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
			GD.Print(velocity);
		}
		else if (Input.IsActionPressed("move_down") && PlayerGlobal.isClimbing)
		{
			velocity += new Vector2(0, ClimbSpeed * (float)delta);
			GD.Print(velocity);
		}
		else if (PlayerGlobal.isClimbing && !Input.IsActionPressed("move_down") && !Input.IsActionPressed("move_up") && !Input.IsActionPressed("jump"))
		{
			velocity = Vector2.Zero;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && (IsOnFloor() || PlayerGlobal.isClimbing) && !IsMovementLocked)
		{
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
			velocity.X = horizonalMovement().X;

		if (Input.IsActionJustPressed("ability") && !IsMovementLocked)
		{
			velocity += Ability();
			velocity = velocity.Clamp(new Vector2(-700, -980), new Vector2(700, 980));
		}

		Velocity = velocity;
		MoveAndSlide();

		if (!PlayerGlobal.isAttacking) Animation();

	}
	public void OnPlayerDeath()
	{
		GD.Print("OnPlayerDeath");
		sprites.Offset = getSpriteOffset("death");
		IsMovementLocked = true;
		sprites.Play("death");
	}
	public void CollideWithEnemy(Node2D b)
	{
		GD.Print("CollideWithEnemy");
		GD.Print(b.Name);
		if (b.Name == "Player") return;

		if(b is CharacterBody2D)
		{
			var body = b as CharacterBody2D;
			uint layer3 = body.CollisionLayer & 0b_0100;
			if (layer3 > 0)
			{
				var enemy = body as BaseEnemy;
				// GD.Print($"Player: {Health} - {enemy.Damage} = {Health -= enemy.Damage}");
				//Health -= enemy.Damage;
				affectHealth(-enemy.Damage);
				// EmitSignal(SignalName.PlayerHealthChange);
			}
		}
		else if (b.GetParent() is CharacterBody2D)
		{
            var body = b.GetParent() as CharacterBody2D;
            uint layer3 = body.CollisionLayer & 0b_0100;
            if (layer3 > 0)
            {
                var enemy = body as BaseEnemy;
                // GD.Print($"Player: {Health} - {enemy.Damage} = {Health -= enemy.Damage}");
                //Health -= enemy.Damage;
				affectHealth(-enemy.Damage);
				// EmitSignal(SignalName.PlayerHealthChange);
            }
        }
		else if (b.Name == "RisingLava")
		{
			if (b.Name == "RisingLava")
			{
				Health = 0;
			}
			EmitSignal(SignalName.PlayerHealthChange);
		}

		if (Health <= 0)
		{
			
			OnPlayerDeath();
		}
		else
		{
			//sprites.Play("Hurt");
			(FindChild("HitboxShape") as CollisionShape2D).SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
			iFrames.Start();
		}
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
		else if (!Input.IsAnythingPressed() && (IsOnFloor() || PlayerGlobal.isClimbing) && !PlayerGlobal.isAttacking && !IsMovementLocked)
		{
			sprites.Offset = getSpriteOffset("idle");
			sprites.Play("idle");
		}
	}

	public void _on_sprites_animation_finished()
	{
		if (PlayerGlobal.isAttacking)
		{
			attackCooldown = false;
			PlayerGlobal.isAttacking = false;

			GetNode("Attack")?.QueueFree();

			if (Input.IsActionPressed("attack"))
				Attack();
		}
		if(Health <= 0)
		{
			EmitSignal(SignalName.PlayerDeath);
		}
		OnAnimationEnd();
	}

	public bool CanAttack()
	{
		return !attackCooldown && !IsMovementLocked;
	}

	public bool CanJump()
	{
		return  (IsOnFloor() || PlayerGlobal.isClimbing) && !IsMovementLocked;
	}

	public virtual void Attack()
	{
		attackCooldown = true;
		PlayerGlobal.isAttacking = true;
		sprites.Offset = getSpriteOffset("attack");
		sprites.Play("attack");
        var Attack = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/attack.tscn").Instantiate() as Attack;
		GD.Print("Attacking");
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

	public override void _Ready()
	{
		SoundController = GetNode("PlayerSoundController");
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
		// if (Health <= 0) OnPlayerDeath();
	}
}
