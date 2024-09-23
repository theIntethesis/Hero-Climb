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

	[Export]
	private PackedScene CharacterCreator;


    public override void _Ready()
    {
        base._Ready();

		Debug.Assert(CharacterCreator != null, "Character Creator is not defined");
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
		Push(CharacterCreator);
	}

	public void EnterGame()
	{
		// should check that a character class has been selected. does not yet, will need to interface with the player controller
		GetTree().Root.AddChild(InitialGameScene.Instantiate());
		QueueFree();
		GetTree().Root.RemoveChild(this);
	}

	public void ResumeGame()
	{

	}

}
