using Godot;
using System;

public partial class MaskMouse : Control
{
	bool Masked = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MouseEntered += OnPanelMouseEntered;
		MouseExited +=OnPanelMouseExited;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("attack") && !Masked)
		{
			GetViewport().SetInputAsHandled();
		}
	}

	public void OnPanelMouseEntered()
	{
		// GD.Print("Masked");
		Masked = true;
	}
	public void OnPanelMouseExited()
	{
		// GD.Print("unmasked");
		Masked = false;
	}
}
