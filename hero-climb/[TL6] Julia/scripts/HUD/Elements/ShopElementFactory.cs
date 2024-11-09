using System.Text.RegularExpressions;
using Godot;

public static partial class ShopElementFactory
{
    const int NumResetOptions = 3;


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

        public MaxHealthIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/MaxHealthShopElement.tscn", Price, Increase)
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

        public FullHeal() : base("res://[TL6] Julia/scenes/HUD Elements/FullHealShopElement.tscn", Price, Increase)
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

    public partial class DamageIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {5, 5, 5};
        static readonly int[] ClassPriceIncrease = {10, 5, 15};

        static int Price;
        static int Increase;

        static int DmgIncrease = 50;

        public override void Buy()
        {
            if (CanBuy())
            {
                Buy();
                PlayerGlobal.AffectBaseDamage(DmgIncrease);
            }
        }

        public static void Reset(int selector)
        {
            Price = ClassBasePrice[(int)selector];
            Increase = ClassPriceIncrease[(int)selector];
        }

        public DamageIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/DamageIncreaseShopElement.tscn", Price, Increase)
        {
        }

        public override void _Ready()
        {
            base._Ready();
            GetNode<Button>("Button").Pressed += Buy;
        }

        ~DamageIncrease()
        {
            Price = CurrentPrice;
        }
    }

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
            if (selector < NumResetOptions)
            {
                Price = ClassBasePrice[selector];
                Increase = ClassPriceIncrease[selector];
                SpdIncrease = ClassSpdIncrease[selector];
            }
        }

        public SpeedIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/SpeedIncreaseShopElement.tscn", Price, Increase)
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

    public static void Reset(int selector)
    {
        MaxHealthIncrease.Reset(selector);
        FullHeal.Reset(selector);
        DamageIncrease.Reset(selector);
        SpeedIncrease.Reset(selector);
    }

    public static ShopElement[] GenerateElements()
    {
        ShopElement[] elements = new ShopElement[4];

        elements[0] = new MaxHealthIncrease();
        elements[1] = new FullHeal();
        elements[2] = new DamageIncrease();
        elements[3] = new SpeedIncrease();

        return elements;
    }
}
