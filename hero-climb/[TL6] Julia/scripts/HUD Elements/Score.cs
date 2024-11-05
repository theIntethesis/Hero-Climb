using Godot;

public partial class ScoreLabel : MenuLeaf
{
    public const string NAME = "SCORE";
    public ScoreLabel(): base(NAME, "res://[TL6] Julia/scenes/HUD Elements/score.tscn")
    {
        CustomMinimumSize = ForegroundNode.Size;
    }

    public void SetScore(int score)
    {
        ForegroundNode.GetNode<Label>("Label").Text = score.ToString();
    }
}