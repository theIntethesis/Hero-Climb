using Godot;

public partial class PlayerCameraStack : MenuStack
{
    public const string NAME = "PlayerCameraStack";

    public GameHUD HUD;

    PlayerCamera ParentCam;


    public PlayerCameraStack(PlayerCamera parent) : base()
    {
        Name = NAME;
        ParentCam = parent;
    }

    public override void _Ready()
    {
        HUD = new GameHUD(PlayerGlobal.GetPlayerMaxHealth());
        Push(HUD);

        HUD.leaf.Hearts.Increment(PlayerGlobal.GetPlayerHealth());
        HUD.leaf.Score.SetScore(PlayerGlobal.Money);

        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerHealthChange, Callable.From<int>(PlayerHealthChangeEventHandler));
        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerDeath, Callable.From(OnPlayerDeath));
        PlayerGlobal.Player.Connect(Controller.SignalName.KaChing, Callable.From(OnKaChing));
    }


    public void OnKaChing()
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

    public void PlayerHealthChangeEventHandler(int change)
    {
        if (change < 0)
        {
            ParentCam.ShakeCamera();
        }

        HUD.leaf.Hearts.SetHealth(change);
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
