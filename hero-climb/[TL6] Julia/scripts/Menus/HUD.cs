using System.Linq;
using System.Linq.Expressions;
using Godot;

public partial class MobileControls : MenuLeaf
{
    public const string NAME = "MobileControls";

    public MobileControls(MenuComposite parent): base(parent, NAME, "res://[TL6] Julia/scenes/HUD Elements/MobileControls.tscn")
    {

    }
}

public partial class GameHUD : MenuComposite
{
    public const string NAME = "GameHUD";

    public HeartGrid Hearts;

    public MobileControls Controls = null;

    public GameHUD(MenuComposite parent, int maxhealth) : base(parent, NAME)
    {
        Hearts = new HeartGrid(this, maxhealth);
        Controls = new MobileControls(this);

        Push(Hearts);
        
        if (OS.GetName() == "Android")
        {
            Push(Controls);
        }
    }

    override public bool Poppable { get { return false; }}

    public override void OnShow()
    {
        GetTree().Paused = false;
    }

    public override void OnHide()
    {
        GetTree().Paused = true;
    }

    public override void OnPop()
    {
        Parent().Push(new PauseMenu(Parent()));
    }
}

public partial class GameShop : MenuComposite
{
    public const string NAME = "GameShop";

    public partial class Element : MenuLeaf
    {
        public Element(MenuComposite parent, string name) : base(parent, name, "res://[TL6] Julia/scenes/HUD Elements/ShopElement.tscn")
        {
            
        }
    }

    public GameShop(MenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/HUD Elements/Shop.tscn")
    {
    
    }

    public override void Push(IMenuElement node)
    {
        if (node is Node cast)
        {
            GetNode<GridContainer>("Control/GridContainer").AddChild(cast);
        }
    }

    public override MenuElement Pop()
    {
        MenuElement last = (MenuElement)GetNode<GridContainer>("Control/GridContainer").GetChildren().Last();
        last.QueueFree();

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


public partial class PlayerCameraStack : MenuStack
{
    public const string NAME = "PlayerCameraStack";

    public GameHUD HUD;


    public PlayerCameraStack(MenuComposite parent, int maxhealth) : base(parent, NAME)
    {
        
        HUD = new GameHUD(this, maxhealth);
        Push(HUD);
    }

    public void OpenShop()
    {
        if (HUD.Child(GameShop.NAME) == null)
        {
            HUD.Push(new GameShop(HUD));
        }
    }

    public void CloseShop()
    {
        if (HUD.Child(GameShop.NAME) != null)
        {
            HUD.Remove(GameShop.NAME);
        }
    }
}