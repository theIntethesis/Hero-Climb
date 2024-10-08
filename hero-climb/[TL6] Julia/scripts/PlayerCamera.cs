using Godot;
using System;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{ 
    private HeartGrid hearts;

    public override void _Ready()
    {
    
        hearts = GetNode<HeartGrid>("HUD/Buffer/HeartGrid");

        if (!(GetParent() is Controller)) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        GD.Print("here");

        hearts.Populate(GetParent<Controller>().getHealth());
        hearts.Set(GetParent<Controller>().getHealth());

        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnPause += this.OnPauseEventHandler;
        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnResume += this.OnResumeEventHandler;
    }

    public void OnPauseEventHandler()
    {
        GetNode<CanvasLayer>("HUD").Visible = false;
    }

    public void OnResumeEventHandler()
    {
        GetNode<CanvasLayer>("HUD").Visible = true;
    }

    public void InjuryEventHandler() 
    {
        hearts.Set(GetParent<Controller>().getHealth());
    }

    public void OnPlayerDeath() 
    {
        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnPlayerDeath();
        GetNode<CanvasLayer>("HUD").Visible = false;
        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnPause -= this.OnPauseEventHandler;
        GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler").OnResume -= this.OnResumeEventHandler;
    }
}
