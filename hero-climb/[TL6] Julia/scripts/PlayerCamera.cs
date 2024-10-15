using Godot;
using System;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{ 
    public HeartGrid hearts;

    public GlobalMenuHandler globalMenuHandler;


    public override void _Ready()
    {
        globalMenuHandler =  GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler");
    
        hearts = GetNode<HeartGrid>("HUD/Buffer/HeartGrid");

        if (!(GetParent() is Controller)) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        hearts.Populate(GetParent<Controller>().getHealth());
        hearts.Set(GetParent<Controller>().getHealth());

        globalMenuHandler.OnPause += this.OnPauseEventHandler;
        globalMenuHandler.OnResume += this.OnResumeEventHandler;
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
        globalMenuHandler.OnPlayerDeath();
        
        GetNode<CanvasLayer>("HUD").Visible = false;
    }

    public void OnGameWin()
    {
        globalMenuHandler.OnGameWin();
    }

    public override void _ExitTree()
    {
        globalMenuHandler.OnPause -= this.OnPauseEventHandler;
        globalMenuHandler.OnResume -= this.OnResumeEventHandler;
    }
}
