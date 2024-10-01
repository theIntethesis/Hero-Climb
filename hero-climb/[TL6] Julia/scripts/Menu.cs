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
	private PackedScene CharacterCreator;


	public bool Resumable = false;

	private GlobalMenuHandler GlobalMenuHandler;

	public override void _Ready()
	{
		
		// Debug.Assert(CharacterCreator != null, "Character Creator is not defined");
		// Debug.Assert(InitialGameScene != null, "Initial Game Scene is not defined");
		Debug.Assert(Stack != null, "Menu Stack Control Node is not defined");

		GlobalMenuHandler = GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler");

	}

	public override void _Process(double delta)
	{
		
		if (Input.IsActionJustPressed("open_menu"))
		{
			Pop();
		}
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
		if (Stack.GetChildCount() == 1) 
		{
			if (Resumable)
			{
				QueueFree();
				GetTree().Root.RemoveChild(this);
				GetTree().Paused = false;
			}
			else 
			{
				QuitGame();
			}
			return;
		}

		Stack.GetChildren().Last().QueueFree();
		Stack.RemoveChild(Stack.GetChildren().Last());
		
		CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
		Last.Visible = true;
	}

	public void QuitGame()
	{
		if (Resumable)
		{
			GlobalMenuHandler.ReturnToMainMenu();
		}
		else 
		{
			// display warning
			GetTree().Quit();
		}
	}

	public void EnterGame(Controller.ClassType cType)
	{
		GlobalMenuHandler.EnterGame(cType);

		QueueFree();
		GetTree().Root.RemoveChild(this);
	}
}
