using Godot;

public partial class FullHeal : ShopElement
{
	static readonly int[] ClassBasePrice = {15, 15, 15};
	static readonly int[] ClassPriceIncrease = {5, 5, 5};

	static int Price;
	static int Increase;

	public override int Buy(int Money)
	{
		int Output = base.Buy(Money);

		if (Output < Money)
		{
			PlayerGlobal.HealToFull();
		}

		return Output;
	}

	public static void Reset(int selector)
	{
		Price = GameDifficultyHandler.Instance().CurrentDifficulty().shopElementParams[ShopElementFactory.ShopElementEnum.FullHeal].BaseCost[selector];
		Increase = GameDifficultyHandler.Instance().CurrentDifficulty().shopElementParams[ShopElementFactory.ShopElementEnum.FullHeal].CostIncrease[selector];

	}

	public FullHeal() : base(Price, Increase)
	{
	}

	public override void _Ready()
	{
		GetNode<Button>("Button").Pressed += ButtonPressed;
		base._Ready();
	}


	public override void _ExitTree()
	{
		Price = CurrentPrice;
	}
}
