using System.Text.RegularExpressions;
using Godot;

public static partial class ShopElementFactory
{
    public partial class MaxHealthIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {10, 10, 10};
        static readonly int[] ClassIncrease = {5, 5, 5};

        static int Price;
        static int Increase;

        static int HealthIncrease = 20;

        public override void Buy()
        {   
            if (PlayerGlobal.Money >= Price) 
            {
                PlayerGlobal.Money -= Price;
                PlayerGlobal.GetSetPlayerMaxHealth(HealthIncrease);
                Price += Increase;
                TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            }
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
        }

        public MaxHealthIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/MaxHealthShopElement.tscn")
        {
        }

        public override void _Ready()
        {
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            TreeNode.GetNode<Button>("Button").Pressed += Buy;

        }
    }

    public partial class FullHeal : ShopElement
    {
        static readonly int[] ClassBasePrice = {15, 15, 15};
        static readonly int[] ClassIncrease = {5, 5, 5};

        static int Price;
        static int Increase;
        
        public override void Buy()
        {   
            if (PlayerGlobal.Money >= Price) 
            {
                PlayerGlobal.Money -= Price;
                PlayerGlobal.HealToFull();
                Price += Increase;
                TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            }
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
        }

        public FullHeal() : base("res://[TL6] Julia/scenes/HUD Elements/FullHealShopElement.tscn")
        {
        }
        
        public override void _Ready()
        {
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            TreeNode.GetNode<Button>("Button").Pressed += Buy;

        }
    }

    public partial class DamageIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {5, 5, 5};
        static readonly int[] ClassIncrease = {10, 5, 15};

        static int Price;
        static int Increase;

        static int DmgIncrease = 50;

        public override void Buy()
        {   
            if (PlayerGlobal.Money >= Price) 
            {
                PlayerGlobal.Money -= Price;
                PlayerGlobal.AffectBaseDamage(DmgIncrease);
                Price += Increase;
                TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            }
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
        }

        public DamageIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/DamageIncreaseShopElement.tscn")
        {
        }
        
        public override void _Ready()
        {
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            TreeNode.GetNode<Button>("Button").Pressed += Buy;

        }
    }

    public partial class SpeedIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {5, 5, 5};
        static readonly int[] ClassIncrease = {10, 5, 15};

        static int Price;
        static int Increase;

        static int[] ClassSpdIncrease = {15, 20, 5};

        static int SpdIncrease;

        public override void Buy()
        {   
            if (PlayerGlobal.Money >= Price)
            {
                PlayerGlobal.Money -= Price;
                PlayerGlobal.AffectBaseMovement(SpdIncrease);
                Price += Increase;
                TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            }
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
            SpdIncrease = ClassSpdIncrease[(int)classType];
        }

        public SpeedIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/SpeedIncreaseShopElement.tscn")
        {
        }

        public override void _Ready()
        {
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
            TreeNode.GetNode<Button>("Button").Pressed += Buy;
        }
    }

    public static void Reset(Controller.ClassType classType)
    {
        MaxHealthIncrease.Reset(classType);
        FullHeal.Reset(classType);
        DamageIncrease.Reset(classType);
        SpeedIncrease.Reset(classType);
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
