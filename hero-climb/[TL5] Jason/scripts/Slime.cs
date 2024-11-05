using Godot;
using System;

public partial class Slime : BaseEnemy
{
	public override void SetupEnemy()
	{
		base.Damage = 25;
		base.Health = 100;
		base.Speed = 20;
		GD.Print("Slime setup complete.");

	}

	public override void EnemyAttack()
	{
		base.EnemyAttack();
		GD.Print("Slime attacks!");
	}

	public override void _Ready()
	{
		GD.Print("Slime ready.");
		base._Ready();
	}
}
