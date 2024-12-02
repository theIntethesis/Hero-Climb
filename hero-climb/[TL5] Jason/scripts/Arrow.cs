using Godot;
using System;

public partial class Arrow : CharacterBody2D
{

	public Vector2 direction = new Vector2(1,0);
	public int Speed = 200;
	public int Damage = 25;
	private int _deleteAfterFrames = 500;

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
    public override void _Process(double delta)
    {
		if (_deleteAfterFrames <= 0)
		{
			QueueFree();
		}
		else _deleteAfterFrames--;
    }
}
