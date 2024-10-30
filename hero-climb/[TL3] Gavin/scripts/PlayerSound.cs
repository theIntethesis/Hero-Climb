// PlayerSound.cs
// Gavin Haynes
// October 28, 2024
// CS383 Software Engineering
// Player sound interface which extends SoundController.

using Godot;
using System;

public partial class PlayerSound : SoundController
{
	private string HeroClass;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		setVolume(80);
		SetHeroClass("Fighter");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void play(string sound)
	{
		if (sound == "Attack") sound = HeroClass + "Attack";
		base.play(sound);
	}

	public bool SetHeroClass(string hero)
	{
		if (hero == "Rogue" || hero == "Wizard" || hero == "Fighter")
		{
			HeroClass = hero;
			return true;
		}
		else return false;
	}
}
