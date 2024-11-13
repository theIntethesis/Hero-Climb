using Godot;
using System;

public partial class Goblin : BaseEnemy
{

	public Goblin()
	{
		Connect(SignalName.Detected, Callable.From(EnemyAttack));
	}
	public override void SetupEnemy()
	{
		base.Damage = 25;
		base.Health = 100;
		base.Speed = 75;
		//GD.Print("Goblin setup complete.");

	}

	public override void EnemyAttack()
	{
		base.IsLunging = true;
		base.EnemyAttack();
		//GD.Print("Goblin attacks!");
	}

	public override void _Ready()
	{
		//GD.Print("Goblin ready.");
		base._Ready();
	}
}
