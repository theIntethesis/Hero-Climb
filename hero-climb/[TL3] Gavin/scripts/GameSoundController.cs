// GameSound.cs
// Gavin Haynes
// November 6, 2024
// CS383 Software Engineering
// The interface to control playing the game soundtrack

using Godot;
using System;

public partial class GameSoundController : SoundController
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetVolume(50);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    
    // Modify SoundController base class to stop all other tracks before beginning another track
    public override bool Play(string sound)
    {
        StopAll();
        return base.Play(sound);
    }
}
