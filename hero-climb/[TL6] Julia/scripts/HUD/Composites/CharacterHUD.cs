using Godot;

public partial class CharacterHUD : MenuComposite
{

    public MobileControls Controls = null;

    [Export]
    int InitialMaxHealth;

    [Export]
    int InitialMoney;

    public CharacterHUD(int maxhealth, int intitialMoney) : base()
    {
        InitialMaxHealth = maxhealth;
        InitialMoney = intitialMoney;
        _IsPoppable = false;
    }

    public CharacterInfo characterInfo;


    public override void _Ready()
    {
        characterInfo = HUDFactory.CharacterInfo();
        AddChild(characterInfo);

        if (OS.GetName() == "Android")
        {
            AddChild(HUDFactory.MobileControls());
        }
        

        Name = "CharacterHUD";

        const float margin = 0.02f;

        SetAnchor(Side.Left, margin, true, false);
        SetAnchor(Side.Right, 1.0f - margin, true, false);
        SetAnchor(Side.Top, margin, true, false);
        SetAnchor(Side.Bottom, 1.0f - margin, true, false);

        characterInfo.Child<HeartGrid>("HeartGrid").IncreaseMaxHealth(InitialMaxHealth);
        characterInfo.Child<HeartGrid>("HeartGrid").Increment(InitialMaxHealth);

        characterInfo.Child<MoneyLabel>("MoneyLabel").SetMoney(InitialMoney);
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
        Parent().Push(MenuFactory.PauseMenu());
    }

    public void OpenShop()
    {
        if (Child("GameShop") == null)
        {          
            MenuElement gameShop = HUDFactory.GameShop();

            Push(gameShop);
        }
    }

    public void CloseShop()
    {
        if (Child("GameShop") != null)
        {
            Remove("GameShop");
        }
    }


    public void OnKaChing()
    {
        characterInfo.Child<MoneyLabel>("MoneyLabel").SetMoney(PlayerGlobal.Money);
    }

    public void OnPlayerHealthChange(int change)
    {
        characterInfo.Child<HeartGrid>("HeartGrid").SetHealth(change);
    }

    public void OnPlayerMaxHealthChange(int change)
    {
        characterInfo.Child<HeartGrid>("HeartGrid").IncreaseMaxHealth(change);
    }

}