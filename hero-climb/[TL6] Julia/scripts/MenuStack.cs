using System.Collections;
using System.Linq;
using Godot;

/* Subclass */
[GlobalClass]
public partial class MenuStack : MenuComposite
{  
    public override void Push(MenuElement Node)
    {
        if (GetChildCount() > 0 && GetChildren().Last() is MenuElement Last) 
        {
		    Last.Hide();
        }
        AddChild(Node);
        Node.Owner = this;
        Node.OnPush();
    }
    
    public override MenuElement Pop()
    {
        if (GetChildren().Last() is MenuElement Child)
        {
            Child.OnPop();
            if (Child.Poppable) 
            {
                RemoveChild(Child);
                Child.QueueFree();
                if (BackgroundNode != null && GetChildren().Last() == BackgroundNode)
                {
                    QueueFree();
                }
                else if (GetChildCount() > 0) 
                {
                    MenuElement Last = (MenuElement)GetChildren().Last();
                    Last.Show();
                }     
            }  
            return Child;
        }
        throw new System.Exception("MenuStack must only contain MenuElements");
    }

    public MenuStack(MenuComposite parent, string BackgroundScene = "") : base(parent, "MenuStack", BackgroundScene)
    {
        Name = "MenuStack";         
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("open_menu"))
        {
            Pop();
            GetViewport().SetInputAsHandled();
        }        
    }
}