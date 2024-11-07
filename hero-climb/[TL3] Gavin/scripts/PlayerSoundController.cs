// PlayerSound.cs
// Gavin Haynes
// CS383 Software Engineering
// October 29, 2024
// The interface for playing the Player's sounds.

using Godot;
using System;

public partial class PlayerSoundController : SoundController
{
	public static string _hero = "Rogue";	// Name of current hero

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetVolume(80);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Set the hero class. Options are "Rogue", "Wizard", and "Fighter"
	public bool SetHero(string choice)
	{
		switch (choice) {
			case "Rogue":	
				break;
			case "Wizard":	
				break;
			case "Fighter":	
				break;
			default:	// doesn't match available options		
				return false;
		}
		_hero = choice;
		return true;
	}

	// Get the name of the current hero.
	public string GetHero()
	{
		return _hero;
	}

	// Prefix a sound's name with the name of the current Hero Class
	public override bool Play(string sound)
	{
		if (sound == "Attack") sound = _hero + "Attack";
		return base.Play(sound);
	}
}
