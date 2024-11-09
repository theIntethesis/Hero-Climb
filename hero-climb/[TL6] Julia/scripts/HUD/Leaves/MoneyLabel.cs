using Godot;

public partial class MoneyLabel : MenuLeaf
{
    public MoneyLabel(): base()
    {
    }

    public void SetMoney(int money)
    {
        GetNode<Label>("Label").Text = money.ToString();
    }
}