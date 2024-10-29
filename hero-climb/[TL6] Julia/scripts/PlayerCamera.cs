using Godot;
using System;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{ 

    private CanvasLayer Interface;

    private PlayerCameraStack Stack;

    public override void _Ready()
    {

        Interface = GetNode<CanvasLayer>("Interface");

        Stack = new PlayerCameraStack();

        Interface.AddChild(Stack);

        // Use the Character Global class instead!
        if (!(GetParent() is Controller)) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        Stack.HUD.Hearts.SetMaxHealth(GetParent<Controller>().MaxHealth);
        Stack.HUD.Hearts.Set(GetParent<Controller>().getHealth());
    }

    public void InjuryEventHandler() 
    {
        Stack.HUD.Hearts.Set(GetParent<Controller>().getHealth());
    }

    public void OnPlayerDeath() 
    {        
        GetNode<CanvasLayer>("HUD").Visible = false;
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
