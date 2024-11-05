using System.Linq;
using System.Linq.Expressions;
using Godot;

public partial class MobileControls : MenuLeaf
{
    public const string NAME = "MobileControls";

    public MobileControls(): base(NAME, "res://[TL6] Julia/scenes/HUD Elements/MobileControls.tscn")
    {
        if (PlayerGlobal.Player.Class != Controller.ClassType.Fighter)
        {
            ForegroundNode.GetNode<TouchScreenButton>("Bottom Left Corner/Bounding Box/2DOrigin/ability").Visible = false;
        }
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
        
        if (OS.GetName() == "Android" || OS.IsDebugBuild())
        {
            Push(Controls);
        }
    }

    override public bool Poppable { get { return false; }}

    public override void OnShow()
    {
        GetTree().Paused = false;
        Input.EmulateMouseFromTouch = false;

    }

    public override void OnHide()
    {
        GetTree().Paused = true;
        Input.EmulateMouseFromTouch = true;
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

    PlayerCamera ParentCam;


    public PlayerCameraStack(PlayerCamera parent) : base(NAME)
    {
        ParentCam = parent;
    }

    public override void _Ready()
    {
        HUD = new GameHUD(PlayerGlobal.GetPlayerMaxHealth());
        Push(HUD);

        HUD.leaf.Hearts.Increment(PlayerGlobal.GetPlayerHealth());
        HUD.leaf.Score.SetScore(PlayerGlobal.Money);

        // PlayerGlobal.Player.PlayerHealthChange += PlayerHealthChangeEventHandler;
        // PlayerGlobal.Player.PlayerDeath += OnPlayerDeath;

        // GetTree().Root.GetNode<Controller>("LevelController/Player").PlayerHealthChange += PlayerHealthChangeEventHandler;
        // GetTree().Root.GetNode<Controller>("LevelController/Player").PlayerDeath += OnPlayerDeath;

        // GetTree().Root.GetNode<Controller>("LevelController/Player").Connect(Controller.SignalName.PlayerHealthChange, Callable.From(PlayerHealthChangeEventHandler));
        // GetTree().Root.GetNode<Controller>("LevelController/Player").Connect(Controller.SignalName.PlayerDeath, Callable.From(OnPlayerDeath));
        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerHealthChange, Callable.From(PlayerHealthChangeEventHandler));  
        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerDeath, Callable.From(OnPlayerDeath));
    }

    public override void _Process(double _delta)
    {
        HUD.leaf.Score.SetScore(PlayerGlobal.Money);
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
        if (PlayerGlobal.GetPlayerHealth() - HUD.leaf.Hearts.DisplayedHealth < 0)
        {
            ParentCam.ShakeCamera();
        }

        HUD.leaf.Hearts.SetHealth(PlayerGlobal.GetPlayerHealth());
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
