using System.Linq;
using Godot;

public class MenuNodeBlueprint
{
    private PackedScene Scene;

    public System.Action OnPop;
    public System.Action AfterPop;
    public System.Action OnPush;
    public System.Action AfterPush;     // can potentially be used to set up actual values on it

    public MenuNodeBlueprint(PackedScene scene)
    {
        Scene = scene;

        OnPop = null;
        AfterPop = null;
        OnPush = null;
        AfterPush = null;   
    }   

    public MenuNode Instantiate()
    {
        MenuNode node = Scene.Instantiate<MenuNode>();
        node.OnPop = OnPop;
        node.AfterPop = AfterPop;

        return node;
    }

}