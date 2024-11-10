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
        };
        GetNode<Button>("GridContainer/Settings").Pressed += () => 
        {
            Parent().Push(MenuFactory.SettingsMenu());
        };
        GetNode<Button>("GridContainer/Credits").Pressed += () => 
        {
            Parent().Push(MenuFactory.CreditsMenu());
        };
        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            Parent().Pop();
        };

        base._Ready();
    }
}