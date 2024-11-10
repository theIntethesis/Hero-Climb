using Godot;

public partial class ShopStressTestRunner : Control
{

    public int NumIterations = 0;

    public GameShop shop;


    public override void _Ready()
    {
        ShopElementFactory.Reset(0);

        
        shop = HUDFactory.GameShop();
        
        SetAnchorsPreset(LayoutPreset.FullRect, true);
        shop.SetAnchorsPreset(LayoutPreset.Center, true);

        AddChild(shop);

        base._Ready();
    }

    public override void _Process(double _delta)
    {
        int result = shop.elements[0].Buy(1000000);
        GD.Print(result);

        NumIterations += 1;

        base._Process(_delta);
    }
}