using Godot

public partial class ShopElementParams
{
    public readonly int BaseCost;
    public readonly int CostIncrease;

    public PlayerParams(int baseCost, int costIncrease)
    {
        BaseCost = baseCost;
        CostIncrease = costIncrease;
    }
}