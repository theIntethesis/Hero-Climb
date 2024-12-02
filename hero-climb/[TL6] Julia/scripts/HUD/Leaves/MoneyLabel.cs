using Godot;

public partial class MoneyLabel : MenuLeaf
{
    public MoneyLabel(): base()
    {
    }

    int displayedValue;

    public void SetMoney(int money)
    {
        if (money > displayedValue)
        {
            GameHandler.Instance().CoinSound();
        }

        displayedValue = money;
        GetNode<Label>("Label").Text = money.ToString();
    }
}