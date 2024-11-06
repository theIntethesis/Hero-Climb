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
    }

    public partial class MaxHealthIncrease : ShopElement
    {
        public override void Buy()
        {   
            base.Buy();
        }
    }

    public partial class FullHeal : ShopElement
    {
        public override void Buy()
        {
            
            base.Buy();
        }
    }

    public partial class DamageIncrease : ShopElement
    {
        public override void Buy()
        {
            
            base.Buy();
        }
    }

    public partial class SpeedIncrease : ShopElement
    {
        public override void Buy()
        {
            
            base.Buy();
        }
    }


    public partial class JumpHeightIncrease : ShopElement
    {
        public override void Buy()
        {
            
            base.Buy();
        }
    }

    class ClassTypeWeights
    {
        public int MaxHealth;
        public int FullHeal;
        public int DamageIncrease;
        public int SpeedIncrease;
        public int JumpHeightIncrease;
    };

    static ClassTypeWeights GetWeights(Controller.ClassType classType)
    {
        switch (classType)
        {
            case Controller.ClassType.Fighter:
                return new ClassTypeWeights
                {
                    MaxHealth = 0,

                };


            
        }
    }


    public static ShopElement[] Supply(Controller.ClassType classType)
    {
        
    }
}
