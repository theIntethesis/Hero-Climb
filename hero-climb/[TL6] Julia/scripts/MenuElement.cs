using System.Linq;
using Godot;

public partial class MenuObject 
{
    public PackedScene Foreground;
    public PackedScene Background;
    
    public System.Action OnPop;
    public System.Action BeforePush;
    public System.Action AfterPush;     // can potentially be used to set up actual values on it

    public MenuObject(PackedScene foreground, PackedScene background = null)
    {
        Foreground = foreground;
        Background = background;

        OnPop = null;
        BeforePush = null;
        AfterPush = null;   
    }   
}