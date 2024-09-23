using Godot;
using System;
using System.Diagnostics;
using System.Linq;

// Menu navigation using a stack
public partial class Menu : Control
{
	[Export]
	private Control Stack;

	[Export]
	private PackedScene InitialGameScene;


    public override void _Ready()
    {
        base._Ready();

		Debug.Assert(InitialGameScene != null, "Initial Game Scene is not defined");
		Debug.Assert(Stack != null, "Menu Stack Control Node is not defined");
    }

    public void Push(PackedScene scene) 
	{
		CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
		Last.Visible = false;

		var child = scene.Instantiate();
		
		Stack.AddChild(child);
		child.Owner = this;
	}

	public void Pop() 
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

	public void HideMenu() 
	{
		GD.Print("Here");
		Visible = false;
	}

	public void StartGame()
	{
		GetTree().Root.AddChild(InitialGameScene.Instantiate());
		QueueFree();
		GetTree().Root.RemoveChild(this);
	}

}
