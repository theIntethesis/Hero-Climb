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
            GameHandler.Instance().ClickSound();
        };

        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
            GameHandler.Instance().ClickSound();
        };

        int FinalScore = (int)(PlayerGlobal.GetSetScore() * GameDifficultyHandler.Instance().ScoreMultiplier());

        GetNode<Label>("GridContainer/Score").Text = $"Score: {FinalScore}";

        GameHandler.Instance().DeathSound();
    }
}
