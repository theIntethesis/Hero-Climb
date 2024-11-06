// GameSound.cs
// Gavin Haynes
// November 6, 2024
// CS383 Software Engineering
// The interface to control playing the game soundtrack

using Godot;
using System;

public partial class GameSound : SoundController
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
    
    // Modify SoundController base class to stop all other tracks before beginning another track
    public override bool play(string sound)
    {
        StopAll();
        return base.play(sound);
    }
}
