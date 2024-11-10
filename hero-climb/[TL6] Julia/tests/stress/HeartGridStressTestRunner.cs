using Godot;

public partial class HeartGridStressTestRunner : Control
{
    public int ExpectedNumChildren { get; private set; } = 0;


    public HeartGrid grid;

    public override void _Ready()
    {
        SetAnchorsPreset(LayoutPreset.FullRect);
        
        grid = HUDFactory.HeartGrid();

        AddChild(grid);

        base._Ready();
    }

    public override void _Process(double _delta)
    {
        grid.IncreaseMaxHealth(20);
        ExpectedNumChildren += 1;
        base._Process(_delta);
    }
}