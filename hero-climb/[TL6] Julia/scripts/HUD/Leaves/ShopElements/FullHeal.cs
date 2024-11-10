using Godot;

public partial class FullHeal : ShopElement
{
    static readonly int[] ClassBasePrice = {15, 15, 15};
    static readonly int[] ClassPriceIncrease = {5, 5, 5};

    static int Price;
    static int Increase;

    public override void Buy()
    {
        if (CanBuy())
        {
            base.Buy();
            PlayerGlobal.HealToFull();
        }
    }

    public static void Reset(int selector)
    {
        Price = ClassBasePrice[(int)selector];
        Increase = ClassPriceIncrease[(int)selector];
    }

    public FullHeal() : base(Price, Increase)
    {
    }

    public override void _Ready()
    {
        GetNode<Button>("Button").Pressed += Buy;
        base._Ready();
    }

    ~FullHeal()
    {
        Price = CurrentPrice;
    }
}