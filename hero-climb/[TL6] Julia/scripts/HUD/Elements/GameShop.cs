using System.Linq;
using Godot;

public partial class GameShop : MenuComposite
{
    public const string NAME = "GameShop";

    Controller.ClassType ClassType;

    public GameShop(Controller.ClassType classType) : base()
    {
        Name = NAME;
        ClassType = classType;
        SetTreeScene("res://[TL6] Julia/scenes/HUD Elements/Shop.tscn");
    }

    public override void Push(IMenuElement node)
    {
        if (node is Node cast)
        {
            TreeNode.GetNode<GridContainer>("Control/GridContainer").AddChild(cast);
            node.OnPush(this);
        }
    }

    public override MenuElement Pop()
    {
        MenuElement last = (MenuElement)TreeNode.GetNode<GridContainer>("Control/GridContainer").GetChildren().Last();
        last.QueueFree();
        last.OnPop();

        return last;
    }

    public override void _Ready()
    {
        TreeNode.GetNode<Button>("Control/Close").Pressed += () => 
        {
            GD.Print("here");
            QueueFree();
        };

    

        // generate items

    }
}
