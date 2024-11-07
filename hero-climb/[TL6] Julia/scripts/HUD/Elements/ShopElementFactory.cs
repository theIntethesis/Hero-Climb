using System.Text.RegularExpressions;
using Godot;

public static partial class ShopElementFactory
{
    public partial class MaxHealthIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {1, 1, 1};
        static readonly int[] ClassIncrease = {1, 1, 1};

        static int Price;
        static int Increase;

        static int HealthIncrease = 20;

        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            PlayerGlobal.BumpPlayerMaxHealth(HealthIncrease);
            Price += Increase;
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
        }
    }

    public partial class FullHeal : ShopElement
    {
        static readonly int[] ClassBasePrice = {1, 1, 1};
        static readonly int[] ClassIncrease = {1, 1, 1};

        static int Price;
        static int Increase;
        
        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            PlayerGlobal.AffectPlayerHealth(PlayerGlobal.GetPlayerMaxHealth());
            Price += Increase;
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
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
        }
    }

    public partial class DamageIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {1, 1, 1};
        static readonly int[] ClassIncrease = {1, 1, 1};

        static int Price;
        static int Increase;

        static int DmgIncrease = 50;

        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            PlayerGlobal.Player.Damage += DmgIncrease;
            Price += Increase;
            base.Buy();
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
        }

        public DamageIncrease() : base("")
        {
        }
        
        public override void _Ready()
        {
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
        }
    }

    public partial class SpeedIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {1, 1, 1};
        static readonly int[] ClassIncrease = {1, 1, 1};

        static int Price;
        static int Increase;

        static int SpdIncrease = 20;

        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            PlayerGlobal.Player.Speed += SpdIncrease;
            Price += Increase;

            base.Buy();
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
        }

        public SpeedIncrease() : base("")
        {
        }

        public override void _Ready()
        {
            TreeNode.GetNode<Label>("Label").Text = Price.ToString();
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
