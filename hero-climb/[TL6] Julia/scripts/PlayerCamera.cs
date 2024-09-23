using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class PlayerCamera : Camera2D
{
	[Export]
	private PackedScene PauseMenu;

	[ExportGroup("Advanced Settings")]
	[Export]
	private Control Overlay;

	[Export]
	private Control HUD;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Debug.Assert(PauseMenu != null, "Pause Menu is not defined");
		Debug.Assert(Overlay != null, "Pause Menu is not defined");
		Debug.Assert(HUD != null, "Pause Menu is not defined");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (Input.IsActionJustPressed("open_menu"))
		{
			PauseGame();
		}
	}

	public void PauseGame() 
	{
		Overlay.AddChild(PauseMenu.Instantiate());
	}
}
