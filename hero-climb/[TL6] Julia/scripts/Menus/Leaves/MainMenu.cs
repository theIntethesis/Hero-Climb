using Godot;

public partial class MainMenu: MenuLeaf
{
    public override void OnPop()
    {
        Parent().Push(MenuFactory.QuitConfirm());
    }

    public override void _Ready()
    {

        GetNode<Button>("GridContainer/Start").Pressed += () => 
        {
            Parent().Push(MenuFactory.CharacterCreator());
            GameHandler.Instance().ClickSound();
        };
        GetNode<Button>("GridContainer/Settings").Pressed += () => 
        {
            Parent().Push(MenuFactory.SettingsMenu());
            GameHandler.Instance().ClickSound();
        };
        GetNode<Button>("GridContainer/Credits").Pressed += () => 
        {
            Parent().Push(MenuFactory.CreditsMenu());
            GameHandler.Instance().ClickSound();
        };
        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            Parent().Pop();
            GameHandler.Instance().ClickSound();
        };

        base._Ready();
    }
}