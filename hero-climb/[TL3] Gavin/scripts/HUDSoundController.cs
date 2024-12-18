// HUDSound.cs
// Gavin Haynes
// November 6, 2024
// CS383 Software Engineering
// The interface to control playing HUD sounds

using Godot;
using System;

public partial class HUDSoundController : SoundController
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetVolume(100);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
