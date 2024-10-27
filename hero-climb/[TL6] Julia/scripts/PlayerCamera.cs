using Godot;
using System;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{ 
    public HeartGrid hearts;

    public override void _Ready()
    {

        hearts = GetNode<HeartGrid>("HUD/Margin/HeartGrid");

        // Use the Character Global class instead!
        if (!(GetParent() is Controller)) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        hearts.SetMaxHealth(GetParent<Controller>().MaxHealth);
        hearts.Set(GetParent<Controller>().getHealth());

        MenuWrapper.Instance().OnPause += this.OnPauseEventHandler;
        MenuWrapper.Instance().OnResume += this.OnResumeEventHandler;

        /*
        ShopElement[] elements = new ShopElement[]
        {
            new ShopElement("res://[TL6] Julia/assets/heart 15x15.png", 2),
            new ShopElement("res://[TL6] Julia/assets/heart 15x15.png", 2),
            new ShopElement("res://[TL6] Julia/assets/heart 15x15.png", 2),
            new ShopElement("res://[TL6] Julia/assets/heart 15x15.png", 2),
            new ShopElement("res://[TL6] Julia/assets/heart 15x15.png", 2),
            new ShopElement("res://[TL6] Julia/assets/heart 15x15.png", 2)
        };

        */

        // OpenShop(elements);
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
        MenuWrapper.Instance().OnPlayerDeath();
        
        GetNode<CanvasLayer>("HUD").Visible = false;
    }

    public void OnGameWin()
    {
        MenuWrapper.Instance().OnGameWin();
    }

    public override void _ExitTree()
    {
        MenuWrapper.Instance().OnPause -= this.OnPauseEventHandler;
        MenuWrapper.Instance().OnResume -= this.OnResumeEventHandler;
    }

    public void OpenShop(ShopElement[] elements)
    {
        Shop shop = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/Shop.tscn").Instantiate() as Shop;
        GetNode<Node>("HUD/Margin").AddChild(shop);
        shop.Name = "Shop";
        shop.Init(elements);
    }
}
