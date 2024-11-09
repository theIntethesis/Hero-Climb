using Godot;

public partial class CharacterHUD : MenuComposite
{
    public partial class CharacterInfo : MenuLeaf
    {
        public HeartGrid heartGrid;
        public MoneyLabel moneyLabel;

        public CharacterInfo()
        {
            GridContainer container = new GridContainer();
            
            AddChild(container);
            container.SetAnchorsAndOffsetsPreset(LayoutPreset.TopLeft);

            heartGrid = HUDFactory.HeartGrid();
            moneyLabel = HUDFactory.MoneyLabel();

            container.AddChild(heartGrid);
            container.AddChild(moneyLabel);
        }
    }
    
    public MobileControls Controls = null;

    int ConstructorParamMaxHealth;

    public CharacterHUD(int maxhealth) : base()
    {
        ConstructorParamMaxHealth = maxhealth;
    }

    public  CharacterInfo characterInfo;


    public override void _Ready()
    {
        characterInfo = new CharacterInfo();
        AddChild(characterInfo);

        Name = "CharacterHUD";

        const float margin = 0.02f;

        SetAnchor(Side.Left, margin);
        SetAnchor(Side.Right, 1.0f - margin);
        SetAnchor(Side.Top, margin);
        SetAnchor(Side.Bottom, 1.0f - margin);

        characterInfo.heartGrid.IncreaseMaxHealth(ConstructorParamMaxHealth);
        characterInfo.heartGrid.Increment(ConstructorParamMaxHealth);
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

    public void OpenShop()
    {
        if (Child(GameShop.NAME) == null)
        {          
            MenuElement gameShop = HUDFactory.GameShop();

            Push(gameShop);
        }
    }

    public void CloseShop()
    {
        if (Child(GameShop.NAME) != null)
        {
            Remove(GameShop.NAME);
        }
    }
}