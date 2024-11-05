using Godot;
using System;

public partial class Skeleton : BaseEnemy
{
	public override void SetupEnemy()
	{
		base.Damage = 25;
		base.Health = 100;
		base.Speed = 50;
		GD.Print("Skeleton setup complete.");

	}

	public override void EnemyAttack()
	{
		base.EnemyAttack();
		GD.Print("Skeleton attacks!");
	}

	public override void _Ready()
	{
		GD.Print("Skeleton ready.");
		base._Ready();
	}
}
