using Godot;
using System;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{ 

    private CanvasLayer Interface;

    private PlayerCameraStack Stack;

    int PlayerHealth;

    int CurrentPlayerHealth 
    {
        get { return GetParent<Controller>().getHealth(); }
    }

    public override void _Ready()
    {
        Interface = GetNode<CanvasLayer>("Interface");

        Stack = new PlayerCameraStack(null, PlayerGlobal.MaxHealth);

        Interface.AddChild(Stack);

        // Use the Character Global class instead!
        if (GetParent() is not Controller) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        PlayerHealth = CurrentPlayerHealth;

        if (GetParent() is Controller controller)
        {
            controller.Injury += InjuryEventHandler;
            controller.IsDead += OnPlayerDeath;
        }

        Stack.HUD.Hearts.Increment(CurrentPlayerHealth);
        
        OpenShop();
    }

    public void InjuryEventHandler() 
    {
        Stack.HUD.Hearts.Decrement(PlayerHealth - CurrentPlayerHealth);
        PlayerHealth = CurrentPlayerHealth;
    }

    public void OnPlayerDeath() 
    {        
        Stack.Push(new DeathScreen(Stack));
    }

    public void OnGameWin()
    {
        Stack.Push(new WinScreen(Stack));
    }

    public void OpenShop()
    {
        Stack.OpenShop();
    }
}   
