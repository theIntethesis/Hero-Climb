using Godot;
using System;

public partial class Pipe : Area2D
{
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "Player" && (body as Controller).Class == Controller.ClassType.Rogue)
			PlayerGlobal.pipes++;
	}
	public void OnBodyExited(Node2D body)
	{
		if (body.Name == "Player" && (body as Controller).Class == Controller.ClassType.Rogue)
			PlayerGlobal.pipes--;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
