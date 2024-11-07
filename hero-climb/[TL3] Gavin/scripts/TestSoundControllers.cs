// TestSoundControllers.cs
// Gavin Haynes
// CS383 Software Engineering
// November 7, 2024

using Godot;
using System;

public partial class TestSoundControllers : Node
{
    static GameSoundController SoundPlayer;
    public override void _Ready()
	{
		SoundPlayer = GetNode<GameSoundController>("GameMusicPlayer");
        SoundPlayer.printSounds();
        SoundPlayer.play("Game");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
