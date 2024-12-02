using Godot;

public abstract partial class ShopElement : MenuLeaf
{
    protected int CurrentPrice;
    protected readonly int CurrentIncrease;
    
    public abstract void AffectPlayer();

    public virtual int Buy(int Money)
    {
        if (Money >= CurrentPrice)
        {
            int OutMoney = Money - CurrentPrice;
            
            CurrentPrice += CurrentIncrease;
            GetNode<Label>("Label").Text = CurrentPrice.ToString();

            AffectPlayer();
            GameHandler.Instance().ClickSound();

            return OutMoney;
        }

        return Money;
    }

    public ShopElement(int currentPrice, int currentIncrease)
    {
        // SetTreeScene(path);
        CurrentPrice = currentPrice;
        CurrentIncrease = currentIncrease;
    }

    public override void _Ready()
    {
        if (GetNode<Label>("Label") == null)
        {
            throw new System.Exception("A ShopElement needs a 'Label' in the scene");
        }

        GetNode<Label>("Label").Text = CurrentPrice.ToString();
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }


    public void ButtonPressed()
    {
        PlayerGlobal.Money = Buy(PlayerGlobal.Money);
    }
}