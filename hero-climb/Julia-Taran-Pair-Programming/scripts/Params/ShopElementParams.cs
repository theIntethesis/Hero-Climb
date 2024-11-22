using Godot

public partial class ShopElementParams
{
    public readonly int BaseCost;
    public readonly int CostIncrease;

    public PlayerParams(int baseCost = 1, int costIncrease = 1)
    {
        BaseCost = baseCost;
        CostIncrease = costIncrease;
    }
}