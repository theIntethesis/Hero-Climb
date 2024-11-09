using Godot;
using System;

public abstract partial class BaseEnemy : CharacterBody2D
{
	#region FIELDS
	[Export] public int Damage = 20;
	public float Gravity = 100.0f;
	public float Speed = 50.0f;
	public int Health = 100;
	public Vector2 direction = new Vector2(1, 0);  // Initial direction: right
	private AnimatedSprite2D sprites;  // Reference to the sprite node
	private Timer turnTimer;  // Timer for handling cooldown between direction changes
	private CharacterBody2D player;
	private bool IsDetectingPlayer = false;
	private Vector2 playerPosition;
	private bool IsDead = false;
	private bool IsIdle = false;
	public bool IsLunging = false;

	#endregion
	
	[Signal] public delegate void OnDeathEventHandler();
	[Signal] public delegate void AttackPlayerEventHandler();
	[Signal] public delegate void TakeDamageEventHandler();
	[Signal] public delegate void DetectingEventHandler();
	[Signal] public delegate void DetectedEventHandler();

	#region SETUP
	public override void _Ready()
	{
		GD.Print("BaseEnemy ready.");

		player = (CharacterBody2D)GetParent().GetParent().GetNode("Player");
		// Get the sprite node
		sprites = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprites.Play("play");

		// Initialize the timer
		turnTimer = new Timer();
		turnTimer.WaitTime = 1.0f; //  One second buffer
		turnTimer.OneShot = true;
		AddChild(turnTimer);
	}

	public virtual void SetupEnemy()
	{
		GD.Print("BaseEnemy setup.");
	}
	#endregion

	public virtual void _Process(double delta)
	{
	}


	public override void _PhysicsProcess(double delta)
	{


		if (Math.Floor(GlobalPosition.X) == Math.Floor(player.GlobalPosition.X)){
			Velocity = new Vector2(0,0);
			IsIdle = true;
		}

		if (IsDetectingPlayer && !IsDead && !IsIdle){
			if (GlobalPosition.X - player.GlobalPosition.X < 0){
				if (Math.Floor(GlobalPosition.Y) == Math.Floor(player.GlobalPosition.Y)){
					EmitSignal(SignalName.Detecting);
				}
				direction = new Vector2(1,0);
			} else {
				if (Math.Floor(GlobalPosition.Y) == Math.Floor(player.GlobalPosition.Y)){
					EmitSignal(SignalName.Detecting);
				}
				direction = new Vector2(-1,0);
			}
			sprites.FlipH = direction.X > 0 ? false : true;
		}

		Vector2 velocity = Velocity;

		// Apply gravity
		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
		}

		// Move the enemy back and forth
		velocity.X = direction.X * Speed;

		// Change direction on wall/ledge collision
		if (IsOnWall() || !IsOnFloor())
		{
			if (turnTimer.IsStopped())
			{
				velocity.X = 0;  // Stop movement
				direction.X *= -1;  // Reverse direction
				FlipSprite();  // Flip the sprite
				turnTimer.Start();  // Start the buffer timer
			}
		}

		if (IsLunging)
		{
			velocity.Y -= 100;
			IsLunging = false;
		}

		// Move the enemy
		if (IsDead || IsIdle){
			Velocity = new Vector2(0,0);
		} else {
			Velocity = velocity;
		}
		
		MoveAndSlide();
	}
	
	#region METHODS
	private void OnArea2DBodyEntered(Node2D body)
	{
		if (body is Controller && !IsDead){
				EnemyAttack();
		}
	}

	private void OnArea2DEntered(Area2D area)
	{
		if (area is Attack){
			EmitSignal(SignalName.TakeDamage);
			var attack = (Attack)area;
			sprites.Play("damage");
			Health = Health - attack.Damage;
			GD.Print("Health: " + Health);
		}
		if (Health <= 0){
			Die();
			GD.Print("Dying now...");
		}
	}

	private void OnDetectorBodyEntered(Node2D body)
	{
		if (body is Controller){
			IsDetectingPlayer = true;
			EmitSignal(SignalName.Detected);
		}
	}

	private void OnDetectorBodyExited(Node2D body)
	{
		if (body is Controller){
			IsDetectingPlayer = false;
		}
	}

	private void FlipSprite()
	{
		sprites.FlipH = !sprites.FlipH;
	}

	public virtual void EnemyAttack()
	{
		sprites.Play("attack");
		EmitSignal(SignalName.AttackPlayer);
	}

	public void OnAnimationFinished()
	{
		if (IsDead){
			EmitSignal(SignalName.OnDeath);
			QueueFree();
		} else if (IsIdle) {
			sprites.Play("stand");
			IsIdle = false;
		} 
		else {
			sprites.Play("play");
		}
		
	}

	private void Die()
	{
		sprites.Play("die");
		CollisionShape2D Hitbox = GetNode<CollisionShape2D>("CollisionShape2D");
		Hitbox.QueueFree();
		GD.Print("Death animation playing");
		IsDead = true;
	}
	#endregion
}	
