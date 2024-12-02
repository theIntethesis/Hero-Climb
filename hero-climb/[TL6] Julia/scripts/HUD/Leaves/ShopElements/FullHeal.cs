using Godot;

public partial class FullHeal : ShopElement
{
	static int Price;
	static int Increase;

    public override void AffectPlayer()
    {
        PlayerGlobal.HealToFull();
    }


	public override int Buy(int Money, bool playsound = true)
	{
		int Output = base.Buy(Money, false);

		return Output;
	}

	public static void Reset(Controller.ClassType selector)
	{
		Price = GameDifficultyHandler.Instance().ShopElementParams(ShopElementFactory.ShopElementEnum.FullHeal).BaseCost[selector];
		Increase = GameDifficultyHandler.Instance().ShopElementParams(ShopElementFactory.ShopElementEnum.FullHeal).CostIncrease[selector];
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
