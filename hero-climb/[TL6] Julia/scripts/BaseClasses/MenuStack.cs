// Julia Abdel-Monem

using System.Linq;
using Godot;

/* Subclass */
public partial class MenuStack : MenuCompositeBase
{  
    public override void Push(MenuElement node)
    {
        if (GetChildCount() > 0 && GetChildren().Last() is MenuElement Last) 
        {
		    Last.Hide();
            Last.OnHide();
        }

        base.Push(node);
    }
    
    public override MenuElement Pop()
    {
        if (GetChildren().Any() == false)
        {
            Parent().Pop();
        }
        
        MenuElement element = base.Pop();

        if (element == null)
        {
            return null;
        }

        if (GetChildCount() > 0 && GetChildren().Last() is MenuElement Last) 
        {  
            Last.Show();
            Last.OnShow();
        }     


        while (GetChildren().Any() == true && GetChildren().Last() is MenuElement background && background.IsBackground())
        {
            background.QueueFree();
            RemoveChild(background);
        }
        
        if (GetChildren().Any() == false)
        {
            Parent().Pop();
        }

        return element;
    }

    public MenuStack() : base()
    {     
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("open_menu"))
        {
            GetViewport().SetInputAsHandled();
            Pop();
        }        
    }

    public override Node GetContainer()
    {
        return this;
    }
}