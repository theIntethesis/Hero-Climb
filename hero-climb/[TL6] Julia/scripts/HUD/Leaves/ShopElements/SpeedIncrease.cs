using System.Collections.Generic;
using Godot;

public partial class SpeedIncrease : ShopElement
{
    static int Price;
    static int Increase;

    static Dictionary<Controller.ClassType, int> ClassSpdIncrease = new Dictionary<Controller.ClassType, int>(){
        {Controller.ClassType.Fighter, 15}, 
        {Controller.ClassType.Wizard, 20}, 
        {Controller.ClassType.Rogue, 5}
    };

    static int SpdIncrease;

    public override void AffectPlayer()
    {
        PlayerGlobal.AffectBaseMovement(SpdIncrease);
    }

    public override int Buy(int Money)
    {
        int Output = base.Buy(Money);

        return Output;
    }

    public static void Reset(Controller.ClassType selector)
    {
        Price = GameDifficultyHandler.Instance().ShopElementParams(ShopElementFactory.ShopElementEnum.SpeedIncrease).BaseCost[selector];
        Increase = GameDifficultyHandler.Instance().ShopElementParams(ShopElementFactory.ShopElementEnum.SpeedIncrease).CostIncrease[selector];
        SpdIncrease = ClassSpdIncrease[selector];
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
