using Godot;

public partial class ScoreLabel : MenuLeaf
{
    public ScoreLabel(): base()
    {
    }

    int displayedValue;

    public void SetScore(int score)
    {
        displayedValue = score;
        GetNode<Label>("Number").Text = score.ToString();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        SetScore(PlayerGlobal.GetSetScore());
    }
}