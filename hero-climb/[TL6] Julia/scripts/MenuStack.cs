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
            Last.OnHide();
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


                if (GetChildCount() > 0 && GetChildren().Last() is MenuElement Last) 
                {
                    
                    Last.Show();
                    Last.OnShow();
                }     
            }  

            if (GetChildren().Last() == BackgroundNode)
            {
                Parent.Pop();
            }

            return Child;
        }
        
        throw new System.Exception("MenuStack must only contain MenuElements");
    }

    public MenuStack(MenuComposite parent, string BackgroundScene = "") : base(parent, "MenuStack", BackgroundScene)
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
}