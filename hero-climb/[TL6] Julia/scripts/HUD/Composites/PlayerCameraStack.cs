using Godot;

public partial class PlayerCameraStack : MenuStack
{
    public CharacterHUD HUD;
    PlayerCamera ParentCam;

    public PlayerCameraStack(PlayerCamera parent) : base()
    {
        SetAnchorsPreset(LayoutPreset.FullRect);
        GD.Print("Here");

        ParentCam = parent;
    }

    public override void _Ready()
    {
        HUD = HUDFactory.CharacterHUD(PlayerGlobal.GetSetPlayerMaxHealth(), PlayerGlobal.Money);
       
        Push(HUD);
    }

    public void OnPlayerDeath() 
    {        
        Push(MenuFactory.DeathScreen());
    }

    public void OnPlayerHealthChange(int change)
    {
        if (change < 0)
        {
            ParentCam.ShakeCamera();
        }
    }
}
