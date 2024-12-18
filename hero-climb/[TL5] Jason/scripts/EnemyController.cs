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
			// Taran Pair Programming -
			uint RandomInt = GD.Randi()%100;
			int SpawnChance = GameDifficultyHandler.Instance().LevelParams().EnemyChance;
			if( RandomInt >= SpawnChance ){continue;}
			// -

			enemyType = rand.Next(4);
			switch (enemyType)
			{
				case 0:
					BaseEnemy enemy0 = (Zombie)ZombieScene.Instantiate();
					enemy0.GlobalPosition = spawnPoint;
					enemy0.Damage = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Zombie).BaseDamage;
					enemy0.SetMaxHealth(GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Zombie).BaseMaxHealth);
					enemy0.Speed = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Zombie).BaseSpeed;
					AddChild(enemy0);
					enemy0.SetupEnemy();  // Custom setup method for enemies
					enemy0.SetScale();
					break;
				case 1:
					BaseEnemy enemy1 = (Skeleton)SkeletonScene.Instantiate();
					enemy1.GlobalPosition = spawnPoint;
					enemy1.Damage = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Skeleton).BaseDamage;
					enemy1.SetMaxHealth(GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Skeleton).BaseMaxHealth);
					enemy1.Speed = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Skeleton).BaseSpeed;
					AddChild(enemy1);
					enemy1.SetupEnemy();  // Custom setup method for enemies
					break;
				case 2:
					BaseEnemy enemy2 = (Slime)SlimeScene.Instantiate();
					enemy2.GlobalPosition = spawnPoint;
					enemy2.Damage = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Slime).BaseDamage;
					enemy2.SetMaxHealth(GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Slime).BaseMaxHealth);
					enemy2.Speed = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Slime).BaseSpeed;
					AddChild(enemy2);
					enemy2.SetupEnemy();  // Custom setup method for enemies
					break;
				case 3:
					BaseEnemy enemy3 = (Goblin)GoblinScene.Instantiate();
					enemy3.GlobalPosition = spawnPoint;
					enemy3.Damage = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Goblin).BaseDamage;
					enemy3.SetMaxHealth(GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Goblin).BaseMaxHealth);
					enemy3.Speed = GameDifficultyHandler.Instance().MonsterParams(MonsterTypes.Goblin).BaseSpeed;
					AddChild(enemy3);
					enemy3.SetupEnemy();  // Custom setup method for enemies
					break;
			}
			// GD.Print("Enemy instantiated.");
		}
	}
}
