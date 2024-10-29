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

    int MaxHealth
    {
        get { return GetParent<Controller>().MaxHealth; }
    }

    public override void _Ready()
    {
        Interface = GetNode<CanvasLayer>("Interface");

        Stack = new PlayerCameraStack(MaxHealth);

        Interface.AddChild(Stack);

        // Use the Character Global class instead!
        if (GetParent() is not Controller) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        PlayerHealth = CurrentPlayerHealth;

        Stack.HUD.Hearts.Increment(CurrentPlayerHealth);
        
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


    public void OpenShop(ShopElement[] elements)
    {
        // Shop shop = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/Shop.tscn").Instantiate() as Shop;
        // GetNode<Node>("HUD/Margin").AddChild(shop);
        // shop.Name = "Shop";
        // shop.Init(elements);
    }

    
}
