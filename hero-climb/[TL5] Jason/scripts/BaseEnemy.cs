using Godot;
using System;

public abstract partial class BaseEnemy : CharacterBody2D
{
    [Export] public float Gravity = 10.0f;
    [Export] public float Speed = 50.0f;
    private Vector2 direction = new Vector2(1, 0);  // Initial direction: right
    private AnimatedSprite2D sprites;  // Reference to the sprite node
    private Timer turnTimer;  // Timer for handling cooldown between direction changes

    public override void _Ready()
    {
        GD.Print("BaseEnemy ready.");

        // Get the sprite node
        sprites = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        // Initialize the timer
        turnTimer = new Timer();
        turnTimer.WaitTime = 0.25f; // Half a second buffer
        turnTimer.OneShot = true;
        turnTimer.Connect("timeout", new Callable(this, nameof(OnTurnTimeout)));
        AddChild(turnTimer);
    }

    public virtual void SetupEnemy()
    {
        GD.Print("BaseEnemy setup.");
    }

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
                Gravity = -1.0f;
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

    private void OnTurnTimeout()
    {
        Gravity = 10.0f;
    }

    private void FlipSprite()
    {
        sprites.FlipH = !sprites.FlipH;
    }

    public virtual void OnAnimationFinished()
    {
    }

    public virtual void Attack()
    {
    }
}
