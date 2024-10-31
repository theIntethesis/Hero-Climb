using System;
using Godot;

public partial class Collectable : Area2D
{
    public void OnAreaEntered(Area2D area)
    {
        OnCollect(area);
    }
    protected virtual void OnCollect(Area2D area)
    {

    }

    public override void _Ready()
    {
        base._Ready();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}
