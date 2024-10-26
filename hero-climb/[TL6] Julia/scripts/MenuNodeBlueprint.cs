using System.Linq;
using Godot;
using System.Collections.Generic;



public class MenuNodeBlueprint
{
    private bool Poppable;

    private PackedScene Foreground;
    private PackedScene Background;

    public System.Action OnPop;
    public System.Action AfterPop;
    public System.Action OnPush;
    public System.Action AfterPush;     // can potentially be used to set up actual values on it

    public MenuNodeBlueprint(string foregound, string background = "", System.Action onPop = null, System.Action afterPop = null, System.Action onPush = null, System.Action afterPush = null, bool poppable = true)
    {
        Foreground = ResourceLoader.Load<PackedScene>(foregound);

        if (background != "")
        {
            Background = ResourceLoader.Load<PackedScene>(background);
        }
        else 
        {
            Background = null;
        }

        OnPop = onPop;
        AfterPop = afterPop;
        OnPush = onPush;
        AfterPush = afterPush; 

        Poppable = poppable;
    }   

    public MenuNodeBlueprint(PackedScene foreground, PackedScene background = null, System.Action onPop = null, System.Action afterPop = null, System.Action onPush = null, System.Action afterPush = null, bool poppable = true)
    {
        Foreground = foreground;
        Background = background;

        OnPop = onPop;
        AfterPop = afterPop;
        OnPush = onPush;
        AfterPush = afterPush; 

        Poppable = poppable;
    }

    public MenuNode Instantiate()
    {
        if (OnPush != null)
        {
            OnPush();
        }

        MenuNode node = Foreground.Instantiate<MenuNode>();
        node.OnPop = OnPop;
        node.AfterPop = AfterPop;
        node.Poppable = Poppable;

        if (Background != null)
        {
            node.BackgroundNode = Background.Instantiate<Node>();
        }
        else 
        {
            node.BackgroundNode = null;
        }

        if (AfterPush != null)
        {
            AfterPush();
        }

        return node;
    }
}