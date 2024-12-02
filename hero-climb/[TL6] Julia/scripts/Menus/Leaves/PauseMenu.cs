using Godot;

public partial class PauseMenu : MenuLeaf
{
    public PauseMenu() : base()
    {

    }

    public override void _Ready()
    {

        GetNode<Button>("GridContainer/Resume").Pressed += () => 
        {
            Parent().Pop();
            GameHandler.Instance().ClickSound();
        };
        GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent().Push(MenuFactory.CharacterCreator());
            GameHandler.Instance().ClickSound();
        };
        GetNode<Button>("GridContainer/Settings").Pressed += () => 
        {
            Parent().Push(MenuFactory.SettingsMenu());
            GameHandler.Instance().ClickSound();
        };            
        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            // Parent.Pop();
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
            GameHandler.Instance().ClickSound();
        };
        
        base._Ready();
    }

}
