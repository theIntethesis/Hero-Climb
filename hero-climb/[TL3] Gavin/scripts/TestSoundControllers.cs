// TestSoundControllers.cs
// Gavin Haynes
// CS383 Software Engineering
// November 7, 2024

using Godot;
using System;

public partial class TestSoundControllers : Node
{
    static HUDSoundController SoundPlayer;
    
	public override void _Ready()
	{
		SoundPlayer = GetNode<HUDSoundController>("HUDSoundController");	// or name of associated SoundPlayer
        
		SoundPlayer.PrintSounds();	// print and get a string list of available sounds
		var vol = SoundPlayer.GetVolume();
		SoundPlayer.SetVolume(80);
		SoundPlayer.ChangeVolume(5);	// change the volume by delta
		SoundPlayer.Play("Click");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
