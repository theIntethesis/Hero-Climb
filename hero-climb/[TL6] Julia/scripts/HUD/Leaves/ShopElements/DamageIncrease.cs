using Godot;

public partial class DamageIncrease : ShopElement
{
	static readonly int[] ClassBasePrice = {5, 5, 5};
	static readonly int[] ClassPriceIncrease = {10, 5, 15};

	static int Price;
	static int Increase;

	static int DmgIncrease = 50;

	public override int Buy(int Money)
	{
		int Output = base.Buy(Money);

		if (Output < Money)
		{
			PlayerGlobal.AffectBaseDamage(DmgIncrease);
		}

		return Output;
	}

	public static void Reset(int selector)
	{
		Price = GameDifficultyHandler.Instance().CurrentDifficulty().shopElementParams[ShopElementFactory.ShopElementEnum.DamageIncrease].BaseCost[selector];
		Increase = GameDifficultyHandler.Instance().CurrentDifficulty().shopElementParams[ShopElementFactory.ShopElementEnum.DamageIncrease].CostIncrease[selector];

	}

	public DamageIncrease() : base(Price, Increase)
	{
	}

	public override void _Ready()
	{
		base._Ready();
		GetNode<Button>("Button").Pressed += ButtonPressed;
	}

	public override void _ExitTree()
	{
		Price = CurrentPrice;
	}
}
