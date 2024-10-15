using Godot;
using System;
using System.Collections.Generic;

public partial class EnemyController : Node2D
{
    [Export] public PackedScene ZombieScene { get; set; }
    private List<Marker2D> spawnPoints = new List<Marker2D>();

    public override void _Ready()
    {
        GD.Print("EnemyController ready.");
        if (ZombieScene == null)
        {
            GD.PrintErr("ZombieScene is not assigned!");
        }
        else
        {
            GD.Print("ZombieScene assigned successfully.");
        }

        foreach (Node child in GetChildren())
        {
            if (child is Marker2D)
            {
                spawnPoints.Add((Marker2D)child);
                GD.Print("Spawn point added: ", child.Name, " at position ", ((Marker2D)child).GlobalPosition);
            }
        }
        GD.Print("Calling SpawnEnemies...");
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        GD.Print("Spawning enemies...");
        foreach (var spawnPoint in spawnPoints)
        {
            var enemy = (Zombie)ZombieScene.Instantiate();
            AddChild(enemy);
            GD.Print("Enemy instantiated.");

            enemy.GlobalPosition = spawnPoint.GlobalPosition;
            GD.Print("Enemy spawned at: ", enemy.GlobalPosition);

            enemy.SetupEnemy();  // Custom setup method for enemies
        }
    }
}
