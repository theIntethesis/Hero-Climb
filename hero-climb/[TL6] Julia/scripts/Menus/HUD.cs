using System.Linq;
using System.Linq.Expressions;
using Godot;

public partial class MobileControls : MenuLeaf
{
    public const string NAME = "MobileControls";

    public MobileControls(): base(NAME, "res://[TL6] Julia/scenes/HUD Elements/MobileControls.tscn")
    {

    }
}

public partial class GameHUD : MenuComposite
{
    public const string NAME = "GameHUD";

    public HeartGrid Hearts;

    public MobileControls Controls = null;

    public GameHUD(int maxhealth) : base(NAME)
    {
        Hearts = new HeartGrid(maxhealth);
        Controls = new MobileControls();

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
        Parent().Push(new PauseMenu());
    }
}


public partial class PlayerCameraStack : MenuStack
{
    public const string NAME = "PlayerCameraStack";

    public GameHUD HUD;


    public PlayerCameraStack(int maxhealth) : base(NAME)
    {
        
        HUD = new GameHUD(maxhealth);
        Push(HUD);
    }

    public void OpenShop(GameShop.Element[] elements)
    {
        if (HUD.Child(GameShop.NAME) == null)
        {
            GameShop shop = new GameShop();
            
            HUD.Push(shop);

            foreach (GameShop.Element element in elements)
            {
                shop.Push(element);
            }
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