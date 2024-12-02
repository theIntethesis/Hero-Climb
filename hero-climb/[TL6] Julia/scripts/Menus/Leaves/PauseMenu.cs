using Godot;

public partial class PauseMenu : MenuLeaf
{
    [Export]
    int PauseMenuVolumeDrop = 16;



    public PauseMenu() : base()
    {

    }

    public override void _Ready()
    {
        // GD.Print("lowering volume");

        int temp = GameHandler.Instance().GameSoundController.GetVolume();
        GameHandler.Instance().GameSoundController.SetVolume(temp / PauseMenuVolumeDrop);


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

    public override void OnPop()
    {
        base.OnPop();
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        int temp = GameHandler.Instance().GameSoundController.GetVolume();
        GameHandler.Instance().GameSoundController.SetVolume(temp * PauseMenuVolumeDrop);
        // GD.Print("raising volume");
    }
    
}
