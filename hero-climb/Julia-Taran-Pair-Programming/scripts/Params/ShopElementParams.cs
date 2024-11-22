using Godot;

public partial class ShopElementParams
{
	public readonly int[] BaseCost;
	public readonly int CostIncrease;

	public ShopElementParams(int[] baseCost, int costIncrease = 1)
	{
		BaseCost = baseCost;
		CostIncrease = costIncrease;
	}
}
