// PlayerSound.cs
// Gavin Haynes
// October 29, 2024
// CS383
// Interface for the PlayerSoundController, which extends SoundController.cs

using Godot;
using System;

public partial class PlayerSound : SoundController
{
	public static string _hero = "Rogue";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		setVolume(80);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Set the hero class. Options are "Rogue", "Wizard", and "Fighter"
	public bool setHero(string choice)
	{
		switch (choice) {
			case "Rogue":	
				break;
			case "Wizard":	
				break;
			case "Fighter":	
				break;
			default:		return false;
		}
		_hero = choice;
		return true;
	}

	public string getHero()
	{
		return _hero;
	}

	public override bool play(string sound)
	{
		if (sound == "Attack") sound = _hero + "Attack";
		return base.play(sound);
	}
}
