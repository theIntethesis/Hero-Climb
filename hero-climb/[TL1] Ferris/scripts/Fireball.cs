using Godot;
using System;
using System.Collections.Generic;

public partial class Fireball : Area2D

{
	[Export]
	public float Speed = 150f;
	[Export]
	public float Damage = 20f;
	[Export]
	public float DeleteAfterNFramees = 300f;

	private Vector2 velocity;
	private Marker2D target = new();
	private List<Line2D> lines = new List<Line2D>();
	
	public void DeleteOnCollision(Node2D body)
	{
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
		// addLine();
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
		target.Position = Position + (GetViewport().GetMousePosition() - GetViewportRect().Size / 2) / 4;
		// GD.PushWarning($"Target:\t{target.Position}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += velocity * (float)delta;
		DeleteAfterNFramees--;
		if (DeleteAfterNFramees <= 0) {
			foreach (Line2D line in lines) { line.QueueFree(); }
			QueueFree();
		}
	}
}
