using Godot;

public partial class MaxHealthIncrease : ShopElement
{
	static readonly int[] ClassBasePrice = {10, 10, 10};
	static readonly int[] ClassPriceIncrease = {5, 5, 5};

	static int Price;
	static int Increase;

	static int HealthIncrease = 20;

	public override int Buy(int Money)
	{
		int Output = base.Buy(Money);

		if (Output < Money)
		{
			PlayerGlobal.GetSetPlayerMaxHealth(HealthIncrease);
		}

		return Output;
	}

	public static void Reset(int selector)
	{
		Price = ClassBasePrice[selector - 1];
		Increase = ClassPriceIncrease[selector - 1];
	}

	public MaxHealthIncrease() : base(Price, Increase)
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
