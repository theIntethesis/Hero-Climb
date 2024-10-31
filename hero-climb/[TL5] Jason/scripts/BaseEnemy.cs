using Godot;
using System;

public abstract partial class BaseEnemy : CharacterBody2D
{
	[Export] public int Damage = 20;
	public float Gravity = 10.0f;
	public float Speed = 50.0f;
	public int Health = 100;
	private Vector2 direction = new Vector2(1, 0);  // Initial direction: right
	private AnimatedSprite2D sprites;  // Reference to the sprite node
	private Timer turnTimer;  // Timer for handling cooldown between direction changes
	private Node player;
	private bool IsDetectingPlayer = false;
	private Vector2 playerPosition;

	public override void _Ready()
	{
		GD.Print("BaseEnemy ready.");


		// Get the sprite node
		sprites = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

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

//	public override void _Process(double delta)
//	{
//		if (IsDetectingPlayer){
//			if (GlobalPosition.X - playerPosition.X < 0){
//				direction = new Vector2(1,0);
//				FlipSprite();
//				GD.Print("Walking right towards player");
//			} else {
//				direction = new Vector2(-1,0);
//				FlipSprite();
//				GD.Print("Walking left towards player");
//			}
//		} else {
//			GD.Print("Not Detecting Player");
//		}
//	}
	public override void _PhysicsProcess(double delta)
	{
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

		// Move the enemy
		Velocity = velocity;
		MoveAndSlide();
	}
	
	private void OnArea2DBodyEntered(Node2D body)
	{
		if (body is Controller){
			GD.Print("Yipee");
		}
		if (body is Fireball){
			GD.Print("Ouch");
		}
	}

	private void OnDetectorBodyEntered(Node2D body)
	{
		if (body is Controller){
			IsDetectingPlayer = true;
			playerPosition = body.GlobalPosition;
			GD.Print("Player Detected");
		}
	}

	private void OnDetectorBodyExited(Node2D body)
	{
		if (body is Controller){
			IsDetectingPlayer = false;
			GD.Print("Player Exited Range");
		}
	}

	private void FlipSprite()
	{
		sprites.FlipH = !sprites.FlipH;
	}

	public virtual void Attack()
	{
	}
}
