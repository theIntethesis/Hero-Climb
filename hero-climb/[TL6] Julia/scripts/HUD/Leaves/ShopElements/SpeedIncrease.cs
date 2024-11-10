using Godot;

public partial class SpeedIncrease : ShopElement
{
    static readonly int[] ClassBasePrice = {5, 5, 5};
    static readonly int[] ClassPriceIncrease = {10, 5, 15};

    static int Price;
    static int Increase;

    static int[] ClassSpdIncrease = {15, 20, 5};

    static int SpdIncrease;

    public override void Buy()
    {
        if (CanBuy())
        {
            base.Buy();
            PlayerGlobal.AffectBaseMovement(SpdIncrease);
        }
    }

    public static void Reset(int selector)
    {
        if (selector < ShopElementFactory.NumResetOptions)
        {
            Price = ClassBasePrice[selector];
            Increase = ClassPriceIncrease[selector];
            SpdIncrease = ClassSpdIncrease[selector];
        }
    }

    public SpeedIncrease() : base(Price, Increase)
    {
    }

    public override void _Ready()
    {
        base._Ready();
        GetNode<Button>("Button").Pressed += Buy;
    }

    ~SpeedIncrease()
    {
        Price = CurrentPrice;
    }
}
