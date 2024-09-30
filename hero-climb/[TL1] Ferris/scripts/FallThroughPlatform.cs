using Godot;
using System;

public partial class FallThroughPlatform : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CollisionShape2D collider = GetChild(0) as CollisionShape2D;
		if (Input.IsActionPressed("move_down"))
		{
			collider.Disabled = true;
		}
		else
			collider.Disabled = false;
	}
}
