using Godot;

public partial class SpeedIncrease : ShopElement
{
    static readonly int[] ClassBasePrice = {5, 5, 5};
    static readonly int[] ClassPriceIncrease = {10, 5, 15};

    static int Price;
    static int Increase;

    static int[] ClassSpdIncrease = {15, 20, 5};

    static int SpdIncrease;

    public override int Buy(int Money)
    {
        int Output = base.Buy(Money);

        if (Output < Money)
        {
            PlayerGlobal.AffectBaseMovement(SpdIncrease);
        }

        return Output;
    }

    public static void Reset(int selector)
    {
        if (selector < ShopElementFactory.NumResetOptions)
        {
		    Price = GameDifficultyHandler.Instance().CurrentDifficulty().shopElementParams[ShopElementFactory.ShopElementEnum.SpeedIncrease].BaseCost[selector];
		    Increase = GameDifficultyHandler.Instance().CurrentDifficulty().shopElementParams[ShopElementFactory.ShopElementEnum.SpeedIncrease].CostIncrease[selector];
            SpdIncrease = ClassSpdIncrease[selector];
        }
    }

    public SpeedIncrease() : base(Price, Increase)
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
