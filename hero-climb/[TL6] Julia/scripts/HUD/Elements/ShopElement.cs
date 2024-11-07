using Godot;

public abstract partial class ShopElement : MenuLeaf
{
    public virtual void Buy()
    {
    }

    public ShopElement(string path)
    {
        SetTreeScene(path);
        
    }

}