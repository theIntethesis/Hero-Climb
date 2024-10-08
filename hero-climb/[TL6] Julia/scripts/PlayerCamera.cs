using Godot;
using System;
using System.Diagnostics;
using System.Linq;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{
    public override void _Ready()
    {
        PackedScene heart = ResourceLoader.Load<PackedScene>("/home/julia/projects/Hero-Climb/hero-climb/[TL6] Julia/scenes/HUD Elements/heart.tscn");
        
        // should be dynamic... need resources from Controller
        for (int i = 0; i < 5; i++)
        {
            GetNode<Node>("HUD/Buffer/HeartGrid").AddChild(heart.Instantiate());
        }

        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnPause += () => 
        {
            GetNode<CanvasLayer>("HUD").Visible = false;
        };
        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnResume += () => 
        {
            GetNode<CanvasLayer>("HUD").Visible = true;
        };
        
    }

    public void OnPlayerDeath() 
    {
        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnPlayerDeath();
        GetNode<CanvasLayer>("HUD").Visible = false;
    }
}
