// SoundController.cs
// Gavin Haynes
// November 5, 2024
// Base class for all of my sound objects

using Godot;
using System;
using System.Collections.Generic;

public partial class SoundController : Node
{
	private int volume;
	
	// SoundController constructor
	public SoundController()
	{
		setVolume(80);
	}

	// Play a sound using the name
	public void play(string sound) {
		foreach (AudioStreamPlayer child in GetChildren())
		{
			if (child.Name == sound)
			{
				child.Play();
				break;
			}
		}
	}
	
	// Print the names of each sound in this controller 
	// and return the list.
	public List<String> printSounds() {
		List<String> sounds = new List<String>();
		foreach (AudioStreamPlayer sound in GetChildren()) {
			sounds.Add(sound.Name);
			GD.Print(sound.Name);
		}
		return sounds;
	}
	
	// Change the volume by delta
	public void changeVolume(int delta) {
		setVolume(volume + delta);
	}
	
	// Return the linear volume
	public int getVolume() {
		return volume;
	}
	
	// Set linear volume and then db volume of children
	public bool setVolume(int vol) {
		if (!checkVolume(vol)) return false;
		volume = vol;
		setChildrenVolume(volume);
		return true;
	}
	
	// Set the decibel volume of each sound child
	private void setChildrenVolume(int vol) {
		float db = volumeToDb(vol);
		GD.Print("Setting DB to " + db);
		foreach (AudioStreamPlayer sound in GetChildren()) {
			sound.VolumeDb = db;
		}
	}
	
	// Convert a linear volume to decibels. If the volume is 0,
	// set decibels to the lowest value possible.
	public float volumeToDb(float vol) {
		return (float)Mathf.LinearToDb(vol/100.0);
	}
	
	// Check that the volume is in range [0-100]
	private bool checkVolume(int vol) {
		return vol >= 0 && vol <= 100;
	}
}
