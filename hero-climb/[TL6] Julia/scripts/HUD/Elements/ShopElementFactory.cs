using System.Text.RegularExpressions;
using Godot;


public static class ShopElementFactory
{
    
    public abstract partial class ShopElement : MenuLeaf
    {
        public virtual void Buy()
        {
            TreeNode.GetNode<Button>("Button").Icon = null;
            TreeNode.GetNode<Label>("Label").Text = "";
        }

        public ShopElement(string path)
        {
            SetTreeScene(path);
        }

    }

    public partial class MaxHealthIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {0, 0, 0};
        static readonly int[] ClassIncrease = {0, 0, 0};
        static readonly int[] ClassChance = {0, 0, 0};

        static int Price;
        static int Increase;
        public static int Chance { get; private set; }

        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            Price += Increase;
            base.Buy();
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
            Chance = ClassChance[(int)classType];
        }

        public MaxHealthIncrease() : base("")
        {
        }
    }

    public partial class FullHeal : ShopElement
    {
        static readonly int[] ClassBasePrice = {0, 0, 0};
        static readonly int[] ClassIncrease = {0, 0, 0};
        static readonly int[] ClassChance = {0, 0, 0};

        static int Price;
        static int Increase;
        public static int Chance { get; private set; }
        
        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            Price += Increase;
            base.Buy();
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
            Chance = ClassChance[(int)classType];
        }

        public FullHeal() : base("")
        {
        }
    }

    public partial class DamageIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {0, 0, 0};
        static readonly int[] ClassIncrease = {0, 0, 0};
        static readonly int[] ClassChance = {0, 0, 0};

        static int Price;
        static int Increase;
        public static int Chance { get; private set; }

        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            Price += Increase;
            base.Buy();
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
            Chance = ClassChance[(int)classType];
        }

        public DamageIncrease() : base("")
        {
        }
    }

    public partial class SpeedIncrease : ShopElement
    {
        static readonly int[] ClassBasePrice = {0, 0, 0};
        static readonly int[] ClassIncrease = {0, 0, 0};
        static readonly int[] ClassChance = {0, 0, 0};

        static int Price;
        static int Increase;
        public static int Chance { get; private set; }

        public override void Buy()
        {   
            PlayerGlobal.Money -= Price;
            Price += Increase;
            base.Buy();
        }

        public static void Reset(Controller.ClassType classType)
        {
            Price = ClassBasePrice[(int)classType];
            Increase = ClassIncrease[(int)classType];
            Chance = ClassChance[(int)classType];
        }

        public SpeedIncrease() : base("")
        {
        }
    }

    public static void Reset(Controller.ClassType classType)
    {
        MaxHealthIncrease.Reset(classType);
        FullHeal.Reset(classType);
        DamageIncrease.Reset(classType);
        SpeedIncrease.Reset(classType);
    }

    public ShopElement[] GenerateElements()
    {
        
    }
}
