using Godot;
using System;
using System.Collections.Generic;

public partial class EnemyController : Node2D
{
	[Export] Vector2[] spawns = new Vector2[0];
	public PackedScene ZombieScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/zombie.tscn");
	
	public override void _Ready()
	{
		GD.Print("EnemyController ready.");
		GD.Print("Calling SpawnEnemies...");
		SpawnEnemies();
	}

	private void SpawnEnemies()
	{		
		GD.Print("Spawning enemies...");
		foreach (var spawnPoint in spawns)
		{
			var enemy = (Zombie)ZombieScene.Instantiate();
			AddChild(enemy);
			GD.Print("Enemy instantiated.");

			enemy.GlobalPosition = spawnPoint;
			GD.Print("Enemy spawned at: ", enemy.GlobalPosition);

			enemy.SetupEnemy();  // Custom setup method for enemies
		}
	}
}
