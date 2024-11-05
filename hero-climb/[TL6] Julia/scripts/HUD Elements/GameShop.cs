using System.Linq;
using Godot;

public partial class GameShop : MenuComposite
{
    public const string NAME = "GameShop";

    public partial class Element : MenuLeaf
    {
        readonly int Price;

        public Element(int price, string name) : base(name, "res://[TL6] Julia/scenes/HUD Elements/ShopElement.tscn")
        {
            Price = price;
        }

        public override void _Ready()
        {
            ForegroundNode.GetNode<Label>("Label").Text = Price.ToString();
        }
    }

    public GameShop() : base(NAME, "res://[TL6] Julia/scenes/HUD Elements/Shop.tscn")
    {
    
    }

    public override void Push(IMenuElement node)
    {
        if (node is Node cast)
        {
            BackgroundNode.GetNode<GridContainer>("Control/GridContainer").AddChild(cast);
            node.OnPush(this);
        }
    }

    public override MenuElement Pop()
    {
        MenuElement last = (MenuElement)BackgroundNode.GetNode<GridContainer>("Control/GridContainer").GetChildren().Last();
        last.QueueFree();
        last.OnPop();

        return last;
    }

    public override void _Ready()
    {
        BackgroundNode.GetNode<Button>("Control/Close").Pressed += () => 
        {
            GD.Print("here");
            QueueFree();
        };
    }
}
