using Godot;

public partial class SettingsMenu : MenuLeaf
{
    HSlider GameMusicSlider;
    HSlider EnemySFXSlider;
    HSlider PlayerSFXSlider;
    HSlider InterfaceSFXSlider;
    HSlider MasterSlider;
    HSlider GameSFXSlider;

    CheckBox InactivityCheckbox;
    CheckBox DemoModeCheckbox;

    public SettingsMenu() : base()
    {

    }

    public override void _Ready()
    {
        GetNode<Button>("Control/Button").Pressed += () => 
        {
            Parent().Pop();
            GameHandler.Instance().ClickSound();
        };

        MasterSlider = GetNode<HSlider>("TabContainer/Audio/GridContainer/MasterSlider");
        GameMusicSlider = GetNode<HSlider>("TabContainer/Audio/GridContainer/GameMusicSlider");
        EnemySFXSlider = GetNode<HSlider>("TabContainer/Audio/GridContainer/EnemySFXSlider");
        PlayerSFXSlider = GetNode<HSlider>("TabContainer/Audio/GridContainer/PlayerSFXSlider");
        InterfaceSFXSlider = GetNode<HSlider>("TabContainer/Audio/GridContainer/InterfaceSFXSlider");  
        GameSFXSlider = GetNode<HSlider>("TabContainer/Audio/GridContainer/GameSFXSlider");

        InactivityCheckbox = GetNode<CheckBox>("TabContainer/Demo Mode/GridContainer/CheckBox");
        DemoModeCheckbox = GetNode<CheckBox>("TabContainer/Demo Mode/GridContainer/CheckBox2");

        MasterSlider.Value = (float)Mathf.DbToLinear(AudioServer.GetBusVolumeDb(0)) * 100.0;
        GameMusicSlider.Value =    (float)Mathf.DbToLinear(AudioServer.GetBusVolumeDb(1)) * 100.0;
        PlayerSFXSlider.Value =    (float)Mathf.DbToLinear(AudioServer.GetBusVolumeDb(2)) * 100.0;
        EnemySFXSlider.Value =     (float)Mathf.DbToLinear(AudioServer.GetBusVolumeDb(3)) * 100.0;
        InterfaceSFXSlider.Value = (float)Mathf.DbToLinear(AudioServer.GetBusVolumeDb(4)) * 100.0;
        GameSFXSlider.Value = (float)Mathf.DbToLinear(AudioServer.GetBusVolumeDb(5)) * 100.0;

        InactivityCheckbox.ButtonPressed = GameHandler.Instance().UseInactivity;
        DemoModeCheckbox.ButtonPressed = GameHandler.Instance().DemoModeActive;

        MasterSlider.DragEnded += (bool changed) => {
            AudioServer.SetBusVolumeDb(0, (float)Mathf.LinearToDb((double)MasterSlider.Value / 100.0));
        };

        GameMusicSlider.DragEnded += (bool changed) => {
            AudioServer.SetBusVolumeDb(1, (float)Mathf.LinearToDb((double)GameMusicSlider.Value / 100.0));
        };

        PlayerSFXSlider.DragEnded += (bool changed) => {
            AudioServer.SetBusVolumeDb(2, (float)Mathf.LinearToDb((double)PlayerSFXSlider.Value / 100.0));
        };

        EnemySFXSlider.DragEnded += (bool changed) => {
            AudioServer.SetBusVolumeDb(3, (float)Mathf.LinearToDb((double)EnemySFXSlider.Value / 100.0));
        };

        InterfaceSFXSlider.DragEnded += (bool changed) => {
            AudioServer.SetBusVolumeDb(4, (float)Mathf.LinearToDb((double)InterfaceSFXSlider.Value / 100.0));
        };

        GameSFXSlider.DragEnded += (bool changed) => {
            AudioServer.SetBusVolumeDb(5, (float)Mathf.LinearToDb((double)GameSFXSlider.Value / 100.0));
        };

        InactivityCheckbox.Toggled += (bool value) => {
            GameHandler.Instance().UseInactivity = value;
        };

        DemoModeCheckbox.Toggled += (bool value) => {
            GameHandler.Instance().DemoModeActive = value;
        };

        base._Ready();
    }
}
