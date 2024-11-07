using Godot;
using System;

public partial class Slime : BaseEnemy
{	
	public PackedScene SlimeScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/slime.tscn");
	[Export] int SplitsRemaining = 2;


	public Slime()
	{
		Connect(SignalName.OnDeath, Callable.From(SpawnSlime));
	}

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

	private void OnTakeDamage()
	{
		GD.Print("took damage");
	}

	private void SpawnSlime()
	{

		if (SplitsRemaining <= 0)
		{
			return;
		}

		Slime enemy2 = (Slime)SlimeScene.Instantiate();
		enemy2.GlobalPosition = this.GlobalPosition + new Vector2(0,-20);
		AddSibling(enemy2);
		enemy2.SetupEnemy();
		enemy2.Scale = new Vector2(enemy2.Scale.X/2,enemy2.Scale.Y/2);
		enemy2.SplitsRemaining = SplitsRemaining - 1;
		enemy2.Velocity = new Vector2(0,0);
		GD.Print("Splitting!");
	}
}
