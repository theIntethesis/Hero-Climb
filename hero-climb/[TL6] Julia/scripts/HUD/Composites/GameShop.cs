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
        GetNode<Button>("Shop/BoundingBox/Close").Pressed += () => 
        {
            QueueFree();
        };

        elements = ShopElementFactory.GenerateElements(); 

        foreach (ShopElement element in elements)
        {
            Push(element);
        }

    }

    public override Node GetContainer()
    {
        return GetNode<GridContainer>("Shop/BoundingBox/GridContainer");
    }
}


