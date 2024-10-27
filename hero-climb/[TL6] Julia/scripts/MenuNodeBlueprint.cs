using System.Linq;
using Godot;
using System.Collections.Generic;



public class MenuNodeBlueprint
{
    private PackedScene Foreground;
    private PackedScene Background;

    public MenuNodeBlueprint(string foregound, string background = "")
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
    }   

    public MenuNodeBlueprint(PackedScene foreground, PackedScene background = null)
    {
        Foreground = foreground;
        Background = background;
    }

    public MenuNode Instantiate()
    {

        MenuNode node = Foreground.Instantiate<MenuNode>();

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