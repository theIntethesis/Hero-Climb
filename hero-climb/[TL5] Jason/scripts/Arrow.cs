using Godot;
using System;

public partial class Arrow : CharacterBody2D
{

	public Vector2 direction = new Vector2(1,0);
	public int Speed = 500;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Move the enemy back and forth
		velocity.X = direction.X * Speed;
		velocity.Y = 0;

		// Move the enemy
		Velocity = velocity;
	
		MoveAndSlide();
	}

	public void Area2DBodyHasEntered(Node2D body)
	{
		if (body is TileMapLayer)
		{
			QueueFree();
		}
	}
}
