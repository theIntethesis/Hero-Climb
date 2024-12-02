using Godot;

public partial class DamageIncrease : ShopElement
{
	static int Price;
	static int Increase;

	static int DmgIncrease = 50;

    public override void AffectPlayer()
    {
        PlayerGlobal.AffectBaseDamage(DmgIncrease);
    }

    public override int Buy(int Money, bool playsound = true)
	{
		int Output = base.Buy(Money);

		return Output;
	}

	public static void Reset(Controller.ClassType selector)
	{
		Price = GameDifficultyHandler.Instance().ShopElementParams(ShopElementFactory.ShopElementEnum.DamageIncrease).BaseCost[selector];
		Increase = GameDifficultyHandler.Instance().ShopElementParams(ShopElementFactory.ShopElementEnum.DamageIncrease).CostIncrease[selector];

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
