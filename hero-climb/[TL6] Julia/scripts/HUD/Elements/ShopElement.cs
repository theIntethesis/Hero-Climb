using Godot;

public abstract partial class ShopElement : MenuLeaf
{
    public abstract void Buy();

    public ShopElement(string path)
    {
        SetTreeScene(path);
        
    }

}