using Godot;

public partial class ShopElement : MenuLeaf
{
    protected int CurrentPrice;
    protected readonly int CurrentIncrease;

    public bool CanBuy()
    {
        return PlayerGlobal.Money >= CurrentPrice;
    }
    
    public virtual void Buy()
    {
        PlayerGlobal.Money -= CurrentPrice;
        CurrentPrice += CurrentIncrease;
        TreeNode.GetNode<Label>("Label").Text = CurrentPrice.ToString();
    }

    public ShopElement(string path, int currentPrice, int currentIncrease)
    {
        SetTreeScene(path);
        CurrentPrice = currentPrice;
        CurrentIncrease = currentIncrease;
    }

    public override void _Ready()
    {
        if (TreeNode.GetNode<Label>("Label") == null)
        {
            throw new System.Exception("A ShopElement needs a 'Label' in the scene");
        }

        TreeNode.GetNode<Label>("Label").Text = CurrentPrice.ToString();
    }

}