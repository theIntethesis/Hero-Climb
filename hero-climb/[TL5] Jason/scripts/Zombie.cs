using Godot;
using System;

public partial class Zombie : BaseEnemy
{
	public override void SetupEnemy()
	{
		base.Damage = 25;
		base.Health = 100;
		base.Speed = 25;
		// GD.Print("Zombie setup complete.");

	}

	public override void SetScale()
	//public new void SetScale()
	{
		base.Scale = new Vector2(1,1);
	}

	public override void EnemyAttack()
	{
		base.EnemyAttack();
		// GD.Print("Zombie attacks!");
	}

	public override void _Ready()
	{
		// GD.Print("Zombie ready.");
		base._Ready();
	}
}
