using System;
using Godot;

internal partial class Attack : Area2D
{
    [Export]
    public int Damage;
    public override void _Ready()
    {
        Damage = (Owner as Controller).Damage;
        // GD.Print("Attack Ready");
    }
}
