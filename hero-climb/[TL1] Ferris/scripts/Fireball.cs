using Godot;
using System;
using System.Collections.Generic;

public partial class Fireball : Attack

{
	[Export]
	public float Speed = 150f;
	[Export]
	public float DeleteAfterNFrames = 300f;

	private Vector2 velocity;
	private Marker2D target = new();
	private List<Line2D> lines = new List<Line2D>();
	
	public void DeleteOnCollision(Node2D body)
	{
		GD.Print($"Fireball collided with {body.Name}");
		if (!body.IsAncestorOf(this) && body.Name != "Player")
		{
			foreach(Line2D line in lines) {line.QueueFree(); }
			QueueFree();
		}
	}

	private void addLine()
	{
		Line2D line = new Line2D();
		line.AddPoint(Position);
		line.AddPoint(target.Position);
		line.Width = 1;
		AddSibling(line);
		lines.Add(line);
	}
	public void setVelocity(bool followMouse = true, bool facingLeft = false)
	{
		if(OS.IsDebugBuild()) addLine();
		var angle = GetAngleTo(target.Position);
		if (!followMouse)
			angle = facingLeft ? (float)Math.PI : 0;
		// GD.PushWarning($"Angle: {angle * 180 / Math.PI}");

		float x = (float)Math.Cos(angle);
		float y = (float)Math.Sin(angle);


		velocity = new Vector2(x, y) * Speed;
		Rotation = angle + (float)Math.PI;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var Player = GetParent().FindChild("Player") as Controller;
		/*var Camera = Player.FindChild("PlayerCamera") as Camera2D;
		var diff = Camera.GetScreenCenterPosition() - Player.Position;
		GD.Print($"Camera Offset: \t{Camera.GetScreenCenterPosition()}");
		GD.Print($"Player Offset: \t{Player.Position}");
		GD.Print($"Difference: \t{diff}");*/
		Damage = Player.Damage;
		target.Position = Position + (GetViewport().GetMousePosition() - GetViewportRect().Size / 2);
		// GD.Print($"Target:\t{target.Position}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += velocity * (float)delta;
		DeleteAfterNFrames--;
		if (DeleteAfterNFrames <= 0) {
			foreach (Line2D line in lines) { line.QueueFree(); }
			QueueFree();
		}
	}
}
