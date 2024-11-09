using System.Linq;
using Godot;

public partial class GameShop : MenuComposite
{
    public const string NAME = "GameShop";

    public GameShop() : base()
    {
        Name = NAME;
    }

    public override void Push(MenuElement node)
    {
        if (node is Node cast)
        {
            GetNode<GridContainer>("Shop/BoundingBox/GridContainer").AddChild(cast);
            node.OnPush(this);
        }
    }

    public override MenuElement Pop()
    {
        MenuElement last = (MenuElement)GetNode<GridContainer>("Shop/BoundingBox/GridContainer").GetChildren().Last();
        last.QueueFree();
        last.OnPop();

        return last;
    }

    public override void _Ready()
    {
        GetNode<Button>("Shop/BoundingBox/Close").Pressed += () => 
        {
            // GD.Print("here");
            QueueFree();
        };

        ShopElement[] elements = ShopElementFactory.GenerateElements(); 

        foreach (ShopElement element in elements)
        {
            Push(element);
        }

    }

    public override MenuElement Child(string name)
    {
        foreach (MenuElement Child in GetNode<GridContainer>("Shop/BoundingBox/GridContainer").GetChildren())
        {
            if (Child.Name == name)
            {
                return Child;
            }
        }
        
        return null;
    }

}


