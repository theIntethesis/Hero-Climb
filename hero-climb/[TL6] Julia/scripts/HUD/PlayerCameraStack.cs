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
