using Godot;

public partial class ScoreLabel : MenuLeaf
{
    public const string NAME = "SCORE";
    public ScoreLabel(): base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/HUD Elements/score.tscn");
        CustomMinimumSize = TreeNode.Size;
    }

    public void SetScore(int score)
    {
        TreeNode.GetNode<Label>("Label").Text = score.ToString();
    }
}