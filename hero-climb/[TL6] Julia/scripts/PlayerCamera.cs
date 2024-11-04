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

        // Use the Character Global class instead!
        if (GetParent() is not Controller) 
        {
            throw new Exception("PlayerCamera must be a child to a Controller");
        }

        if (GetParent() is Controller controller)
        {
            Stack = new PlayerCameraStack(controller);
            Interface.AddChild(Stack);
        }

        // OpenShop();
    }

    public void OpenShop()
    {
        GameShop.Element[] elements = new GameShop.Element[]
        {
            new(10, "Element.0"),
            new(10, "Element.1"),
            new(10, "Element.2"),
            new(10, "Element.3"),
            new(10, "Element.4"),
            new(10, "Element.5")
        };
        Stack.OpenShop(elements);
        
    }
}   
