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
    public partial class HUDLeaf: MenuLeaf
    {
        public HeartGrid Hearts;

        public ScoreLabel Score;

        public HUDLeaf(int maxhealth) : base("HUDLeaf", "")
        {
            ForegroundNode = new GridContainer();

            Hearts = new HeartGrid(maxhealth);
            Score = new ScoreLabel();
            
            Scale = new Vector2(3.0f, 3.0f);
        }

        public override void _Ready()
        {
            AddChild(ForegroundNode);
            ForegroundNode.AddChild(Hearts);
            ForegroundNode.AddChild(Score);
        }
    }
    
    public HUDLeaf leaf;

    public const string NAME = "GameHUD";

    public MobileControls Controls = null;

    public GameHUD(int maxhealth) : base(NAME)
    {
        leaf = new HUDLeaf(maxhealth);

        Controls = new MobileControls();

        const float margin = 0.02f;

        SetAnchor(Side.Left, margin);
        SetAnchor(Side.Right, 1.0f - margin);
        SetAnchor(Side.Top, margin);
        SetAnchor(Side.Bottom, 1.0f - margin);

        Push(leaf);
        
        if (OS.GetName() == "Android" || 1 == 1)
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

    Controller PlayerRef;
    PlayerCamera ParentCam;


    public PlayerCameraStack(Controller player, PlayerCamera parent) : base(NAME)
    {
        PlayerRef = player;
        ParentCam = parent;
    }

    public override void _Ready()
    {
        HUD = new GameHUD(PlayerRef.MaxHealth);
        Push(HUD);

        HUD.leaf.Hearts.Increment(PlayerRef.getHealth());
        HUD.leaf.Score.SetScore(PlayerGlobal.Money);

        //PlayerRef.PlayerHealthChange += PlayerHealthChangeEventHandler;
        PlayerRef.Injury += PlayerHealthChangeEventHandler;
        PlayerRef.PlayerDeath += OnPlayerDeath;
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

    public void PlayerHealthChangeEventHandler()
    {
        if (PlayerGlobal.Health - HUD.leaf.Hearts.DisplayedHealth < 0)
        {
            ParentCam.ShakeCamera();
        }

        HUD.leaf.Hearts.SetHealth(PlayerGlobal.Health);
    }

    public void OnPlayerDeath() 
    {        
        Push(new DeathScreen());
    }

    public void OnGameWin()
    {
        Push(new WinScreen());
    }

}
