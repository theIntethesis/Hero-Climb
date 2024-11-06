using Godot;

public interface IShopElement
{
    public abstract int Price();
    public abstract string Name();
}

public partial class Element : MenuLeaf
{
    readonly int Price;

    public Element(int price, string name) : base()
    {
        Price = price;
        Name = name;
        SetTreeScene("res://[TL6] Julia/scenes/HUD Elements/ShopElement.tscn");
    }

    public override void _Ready()
    {
        TreeNode.GetNode<Label>("Label").Text = Price.ToString();
    }
}
