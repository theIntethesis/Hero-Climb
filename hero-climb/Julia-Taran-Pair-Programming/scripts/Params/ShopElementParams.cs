using System.Collections.Generic;
using Godot;

public partial class ShopElementParams
{
	public readonly Dictionary<Controller.ClassType, int> BaseCost;
	public readonly Dictionary<Controller.ClassType, int> CostIncrease;

	public ShopElementParams(Dictionary<Controller.ClassType, int> baseCost, Dictionary<Controller.ClassType, int> costIncrease)
	{
		BaseCost = baseCost;
		CostIncrease = costIncrease;
	}
}
