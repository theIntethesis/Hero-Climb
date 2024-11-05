using Godot;
using System;
using System.Collections.Generic;

public partial class EnemyController : Node2D
{
	[Export] Vector2[] spawns = new Vector2[0];
	public PackedScene ZombieScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/zombie.tscn");
	//public PackedScene SkeletonScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/zombie.tscn");
	//public PackedScene SlimeScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/zombie.tscn");
	//public PackedScene GoblinScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/zombie.tscn");

	public override void _Ready()
	{
		GD.Print("EnemyController ready.");
		GD.Print("Calling SpawnEnemies...");
		SpawnEnemies();
	}



	private void SpawnEnemies()
	{

		var rand = new Random();
		int enemyType = rand.Next(3);
		
		//Nonrandom Enemy Type for Testing
		enemyType = 0;
		// *********


		GD.Print("Spawning enemies...");


		foreach (var spawnPoint in spawns)
		{
			switch (enemyType)
			{
				case 0:
					BaseEnemy enemy0 = (BaseEnemy)ZombieScene.Instantiate();
					enemy0.GlobalPosition = spawnPoint;
					AddChild(enemy0);
					enemy0.SetupEnemy();  // Custom setup method for enemies
					break;
				/*
				case 1:
					var enemy1 = (Skeleton)SkeletonScene.Instantiate();
					AddChild(enemy1);
					enemy1.GlobalPosition = spawnPoint;
					enemy1.SetupEnemy();  // Custom setup method for enemies
					break;
				case 2:
					var enemy2 = (Slime)SlimeScene.Instantiate();
					AddChild(enemy2);
					enemy2.GlobalPosition = spawnPoint;
					enemy2.SetupEnemy();  // Custom setup method for enemies
					break;
				case 3:
					var enemy3 = (Goblin)GoblinScene.Instantiate();
					AddChild(enemy3);
					enemy3.GlobalPosition = spawnPoint;
					enemy3.SetupEnemy();  // Custom setup method for enemies
					break;
				*/
			}
			GD.Print("Enemy instantiated.");
		}
	}
}
