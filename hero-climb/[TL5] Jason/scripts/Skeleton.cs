using Godot;
using System;

public partial class Skeleton : BaseEnemy
{

	public PackedScene ArrowScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/arrow.tscn");
	public PackedScene SlimeScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/slime.tscn");
	private Timer Cooldown;
	private bool CanShoot = true;

	public Skeleton()
	{
		Connect(SignalName.Detecting, Callable.From(EnemyAttack));
	}

	public override void _Ready()
	{
		Cooldown = GetNode<Timer>("Cooldown");

		//GD.Print("Skeleton ready.");
		base._Ready();
	}

	public override void SetupEnemy()
	{
		base.Damage = 25;
		base.Health = 100;
		base.Speed = 50;
		//GD.Print("Skeleton setup complete.");

	}

	public override void EnemyAttack()
	{
		if (!CanShoot)
		{
			return;
		}
		Cooldown.Start();
		CanShoot = false;

		Arrow arrow = (Arrow)ArrowScene.Instantiate();
		arrow.direction.X = base.direction.X;
		arrow.GlobalPosition = this.GlobalPosition;

		AddSibling(arrow);
		//GD.Print("Skeleton attacks!");
		base.EnemyAttack();
	}

	public void OnCooldownTimeout()
	{
		CanShoot = true;
	}



}
