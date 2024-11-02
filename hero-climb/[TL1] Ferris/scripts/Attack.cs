using System;
using Godot;

public partial class Attack : Area2D
{
	[Export]
	public int Damage = 0;
	public override void _Ready()
	{
		Damage = (GetParent() as Controller).Damage;
		base._Ready();
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
