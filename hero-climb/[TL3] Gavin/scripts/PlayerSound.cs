// PlayerSound.cs
// Gavin Haynes
// October 29, 2024
// CS383
// Interface for the PlayerSoundController, which extends SoundController.cs

using Godot;
using System;

public partial class PlayerSound : SoundController
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		setVolume(80);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
