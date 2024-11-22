using Godot;
using System;
using System.Collections.Generic;

public partial class EnemyController : Node2D
{
	[Export] Vector2[] spawns = new Vector2[0];
	public PackedScene ZombieScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/zombie.tscn");
	public PackedScene SkeletonScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/skeleton.tscn");
	public PackedScene SlimeScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/slime.tscn");
	public PackedScene GoblinScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/goblin.tscn");
	public PackedScene ArrowScene = GD.Load<PackedScene>("res://[TL5] Jason/scenes/arrow.tscn");


	public enum MonsterTypes
	{
		Zombie,
		Skeleton,
		Slime, 
		Goblin
	}

	private void SpawnEnemies(int health = 100, int damage = 25)
	{

		var rand = new Random();

		// GD.Print("Spawning enemies...");

		int enemyType;
		foreach (var spawnPoint in spawns)
		{
			enemyType = rand.Next(4);
			switch (enemyType)
			{
				case 0:
					BaseEnemy enemy0 = (Zombie)ZombieScene.Instantiate();
					enemy0.GlobalPosition = spawnPoint;
					enemy0.Damage = damage;
					enemy0.SetMaxHealth(health);
					AddChild(enemy0);
					enemy0.SetupEnemy();  // Custom setup method for enemies
					enemy0.SetScale();
					break;
				case 1:
					BaseEnemy enemy1 = (Skeleton)SkeletonScene.Instantiate();
					enemy1.GlobalPosition = spawnPoint;
					enemy1.Damage = damage;
					enemy1.SetMaxHealth(health);
					AddChild(enemy1);
					enemy1.SetupEnemy();  // Custom setup method for enemies
					break;
				case 2:
					BaseEnemy enemy2 = (Slime)SlimeScene.Instantiate();
					enemy2.GlobalPosition = spawnPoint;
					enemy2.Damage = damage;
					enemy2.SetMaxHealth(health);
					AddChild(enemy2);
					enemy2.SetupEnemy();  // Custom setup method for enemies
					break;
				case 3:
					BaseEnemy enemy3 = (Goblin)GoblinScene.Instantiate();
					enemy3.GlobalPosition = spawnPoint;
					enemy3.Damage = damage;
					enemy3.SetMaxHealth(health);
					AddChild(enemy3);
					enemy3.SetupEnemy();  // Custom setup method for enemies
					break;
			}
			// GD.Print("Enemy instantiated.");
		}
	}
}
