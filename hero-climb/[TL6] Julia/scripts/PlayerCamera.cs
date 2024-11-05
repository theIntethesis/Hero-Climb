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

        Stack = new PlayerCameraStack(PlayerGlobal.GetPlayerMaxHealth());

        Interface.AddChild(Stack);

        // Use the Character Global class instead!
        if (GetParent() is not Controller) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        PlayerHealth = CurrentPlayerHealth;

        if (GetParent() is Controller controller)
        {
            controller.PlayerHealthChange += InjuryEventHandler;
            controller.PlayerDeath += OnPlayerDeath;
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
        Stack.Push(new DeathScreen());
    }

    public void OnGameWin()
    {
        Stack.Push(new WinScreen());
    }

    public void OpenShop()
    {
        GameShop.Element[] elements = new GameShop.Element[]
        {
            new GameShop.Element("Element.0"),
            new GameShop.Element("Element.1"),
            new GameShop.Element("Element.2"),
            new GameShop.Element("Element.3"),
            new GameShop.Element("Element.4"),
            new GameShop.Element("Element.5")
        };
        Stack.OpenShop(elements);
        
    }
}   
