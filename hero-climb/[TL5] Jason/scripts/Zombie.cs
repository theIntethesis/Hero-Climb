using Godot;
using System;

public partial class Zombie : BaseEnemy
{
    public override void SetupEnemy()
    {
        base.SetupEnemy();
        GD.Print("Zombie setup complete.");
    }

    public override void OnAnimationFinished()
    {
        base.OnAnimationFinished();
        GD.Print("Zombie animation finished.");
    }

    public override void Attack()
    {
        base.Attack();
        GD.Print("Zombie attacks!");
    }

    public override void _Ready()
    {
        GD.Print("Zombie ready.");
        base._Ready();
    }
}
