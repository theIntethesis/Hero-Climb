using Godot;

public partial class MaxHealthIncrease : ShopElement
{
    static readonly int[] ClassBasePrice = {10, 10, 10};
    static readonly int[] ClassPriceIncrease = {5, 5, 5};

    static int Price;
    static int Increase;

    static int HealthIncrease = 20;

    public override void Buy()
    {
        if (CanBuy())
        {
            base.Buy();
            PlayerGlobal.GetSetPlayerMaxHealth(HealthIncrease);
        }
    }

    public static void Reset(int selector)
    {

        Price = ClassBasePrice[(int)selector];
        Increase = ClassPriceIncrease[(int)selector];
    }

    public MaxHealthIncrease() : base(Price, Increase)
    {
    }

    public override void _Ready()
    {
        GetNode<Button>("Button").Pressed += Buy;
        base._Ready();
    }

    ~MaxHealthIncrease()
    {
        Price = CurrentPrice;
    }
}