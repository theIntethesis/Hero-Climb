using Godot;

public partial class CharacterHUD : MenuComposite
{
    public MobileControls Controls = null;

    int ConstructorParamMaxHealth;

    public CharacterHUD(int maxhealth) : base()
    {
        ConstructorParamMaxHealth = maxhealth;

    }


    public HeartGrid heartGrid;
    public MoneyLabel moneyLabel;

    public override void _Ready()
    {

        GridContainer container = new GridContainer();
        
        AddChild(container);
        container.SetAnchorsAndOffsetsPreset(LayoutPreset.TopLeft);

        heartGrid = HUDFactory.HeartGrid();
        moneyLabel = HUDFactory.MoneyLabel();

        container.AddChild(heartGrid);
        container.AddChild(moneyLabel);

        Name = "CharacterHUD";

        const float margin = 0.02f;

        SetAnchor(Side.Left, margin);
        SetAnchor(Side.Right, 1.0f - margin);
        SetAnchor(Side.Top, margin);
        SetAnchor(Side.Bottom, 1.0f - margin);

        heartGrid.IncreaseMaxHealth(ConstructorParamMaxHealth);
        heartGrid.Increment(ConstructorParamMaxHealth);
    }

    // override public bool Poppable() {  return false; }

    public override void OnShow()
    {
        GetTree().Paused = false;
        Input.EmulateMouseFromTouch = false;

    }

    public override void OnHide()
    {
        GetTree().Paused = true;
        Input.EmulateMouseFromTouch = true;
    }

    public override void OnPop()
    {
        Parent().Push(new PauseMenu());
    }
}