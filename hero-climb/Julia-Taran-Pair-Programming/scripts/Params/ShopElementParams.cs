using System.Collections.Generic;
using System;
using Godot;

public partial class ShopElementParams
{
	public readonly Dictionary<Controller.ClassType, int> BaseCost;
	public readonly Dictionary<Controller.ClassType, int> CostIncrease;

	public ShopElementParams(Dictionary<Controller.ClassType, int> baseCost, Dictionary<Controller.ClassType, int> costIncrease)
	{
		BaseCost = baseCost;
		CostIncrease = costIncrease;
		Validate();
	}

    void Validate()
    {
        foreach (Controller.ClassType key in Enum.GetValues<Controller.ClassType>())
        {
            if (BaseCost.ContainsKey(key) == false)
            {
                throw new Exception("ShopElementParams is incorrectly setup - BaseCost");
            }
			if (CostIncrease.ContainsKey(key) == false)
            {
                throw new Exception("ShopElementParams is incorrectly setup - CostIncrease");
            }
        }
	}
}
