using System.Linq;
using Godot;
using System.Collections.Generic;



public class MenuNodeBlueprint
{
    private bool Poppable;

    private PackedScene Foreground;
    private PackedScene Background;

    public MenuNodeBlueprint(string foregound, string background = "", bool poppable = true)
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


        Poppable = poppable;
    }   

    public MenuNodeBlueprint(PackedScene foreground, PackedScene background = null, bool poppable = true)
    {
        Foreground = foreground;
        Background = background;

 
        Poppable = poppable;
    }

    public MenuNode Instantiate()
    {

        MenuNode node = Foreground.Instantiate<MenuNode>();
        node.Poppable = Poppable;

        if (Background != null)
        {
            node.BackgroundNode = Background.Instantiate<Node>();
        }
        else 
        {
            node.BackgroundNode = null;
        }

        return node;
    }
}