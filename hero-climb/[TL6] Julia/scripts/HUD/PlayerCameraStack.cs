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
        HUD = new GameHUD(PlayerGlobal.GetSetPlayerMaxHealth());
        Push(HUD);

        HUD.leaf.Hearts.Increment(PlayerGlobal.AffectPlayerHealth());
        HUD.leaf.Score.SetScore(PlayerGlobal.Money);

        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerHealthChange, Callable.From<int>(PlayerHealthChangeEventHandler));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerDeath, Callable.From(OnPlayerDeath));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.KaChing, Callable.From(OnKaChing));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.ShutUpAndTakeMyMoney, Callable.From(OpenShop));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerMaxHealthChange, Callable.From<int>(PlayerMaxHealthChangeEventHandler));

    }


    public void OnKaChing()
    {
        HUD.leaf.Score.SetScore(PlayerGlobal.Money);
    }

    public void OpenShop()
    {
        if (HUD.Child(GameShop.NAME) == null)
        {
            GameShop shop = new GameShop(PlayerGlobal.GetClassType());
            
            HUD.Push(shop);

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

    public void PlayerMaxHealthChangeEventHandler(int change)
    {
        HUD.leaf.Hearts.IncreaseMaxHealth(change);
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
