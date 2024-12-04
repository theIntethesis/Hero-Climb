using System.Linq;
using Godot;

public partial class GameShop : MenuCompositeBase
{
    public GameShop() : base()
    {
    }

    public ShopElement[] elements;

    public override void _Ready()
    {
        GetNode<Button>("Shop/BoundingBox/HFlowContainer/CenterContainer/Close").Pressed += () => 
        {
            QueueFree();
            GameHandler.Instance().ClickSound();
        };

        elements = ShopElementFactory.GenerateElements(); 

        foreach (ShopElement element in elements)
        {
            Push(element);
        }       
    }

    public override Node GetContainer()
    {
        return GetNode<GridContainer>("Shop/BoundingBox/HFlowContainer/GridContainer");
    }

    public override void _Process(double _delta)
    {
        if (PlayerGlobal.InShopArea == false)
        {
            // QueueFree();
        }
    }

    public override void OnPop()
    {
        base.OnPop();
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }
}


