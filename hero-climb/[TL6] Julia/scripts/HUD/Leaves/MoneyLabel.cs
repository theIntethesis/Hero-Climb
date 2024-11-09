using Godot;

public partial class MoneyLabel : MenuLeaf
{
    public MoneyLabel(): base()
    {
    }

    public void SetScore(int score)
    {
        GetNode<Label>("Label").Text = score.ToString();
    }
}