using Godot;

public partial class PlayerCameraStack : MenuStack
{
    public CharacterHUD HUD;


    PlayerCamera ParentCam;

    public PlayerCameraStack(PlayerCamera parent) : base()
    {
        Name = "PlayerCameraStack";
        ParentCam = parent;
    }

    public override void _Ready()
    {
        HUD = HUDFactory.CharacterHUD(PlayerGlobal.GetSetPlayerMaxHealth());
        Push(HUD);


        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerHealthChange, Callable.From<int>(PlayerHealthChangeEventHandler));
        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerDeath, Callable.From(OnPlayerDeath));
        PlayerGlobal.Player.Connect(Controller.SignalName.KaChing, Callable.From(OnKaChing));
        PlayerGlobal.Player.Connect(Controller.SignalName.ShutUpAndTakeMyMoney, Callable.From(HUD.OpenShop));
        PlayerGlobal.Player.Connect(Controller.SignalName.PlayerMaxHealthChange, Callable.From<int>(PlayerMaxHealthChangeEventHandler));

        HUD.OpenShop();
    }

    public void OnKaChing()
    {
        HUD.characterInfo.moneyLabel.SetScore(PlayerGlobal.Money);
    }



    public void PlayerHealthChangeEventHandler(int change)
    {
        if (change < 0)
        {
            ParentCam.ShakeCamera();
        }

        HUD.characterInfo.heartGrid.SetHealth(change);
    }

    public void PlayerMaxHealthChangeEventHandler(int change)
    {
        HUD.characterInfo.heartGrid.IncreaseMaxHealth(change);
    }

    public void OnPlayerDeath() 
    {        
        Push(new DeathScreen());
    }
}
