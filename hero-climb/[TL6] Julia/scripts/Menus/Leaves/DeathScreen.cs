using Godot;

public partial class DeathScreen : MenuLeaf
{
    public DeathScreen() : base()
    {

    }

    public override void _Ready()
    {
        base._Ready();
        GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent().Push(MenuFactory.CharacterCreator());
        };

        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
        };

        GetNode<Label>("GridContainer/Score").Text = $"Score: {PlayerGlobal.Score}";
    }
}