using Godot;
using System;
using System.Diagnostics;
using System.Linq;

// Menu navigation using a stack
public partial class Menu : Control
{
	[Export]
	private Control Stack;

    public override void _Ready()
    {
        base._Ready();

		Debug.Assert(Stack != null, "Menu Stack Control Node is not defined");
    }

    public void push(PackedScene scene) 
	{
		CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
		Last.Visible = false;

		var child = scene.Instantiate();
		
		Stack.AddChild(child);
		child.Owner = this;
	}

	public void pop() 
	{
		if (Stack.GetChildCount() == 0) 
		{
			return;
		}

		Stack.GetChildren().Last().QueueFree();
		Stack.RemoveChild(Stack.GetChildren().Last());
		
		CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
		Last.Visible = true;

	}

}
