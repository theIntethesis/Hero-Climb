// SoundController.cs
// Gavin Haynes
// CS383 Software Engineering
// November 5, 2024
// Base class for all SoundControllers

using Godot;
using System;
using System.Collections.Generic;

public partial class SoundController : Node2D
{
	private int volume;		// linear volume [0-100]
	
	// SoundController constructor
	public SoundController()
	{
		SetVolume(80);
	}

	// Play a sound using the name
	public virtual bool Play(string sound) {
		foreach (AudioStreamPlayer child in GetChildren())
		{
			if (child.Name == sound)
			{
				if (!child.Playing)
					child.Play();
				return true;
			}
		}
		return false;
	}

	public bool isPlaying(string soundName)
	{
		foreach (AudioStreamPlayer child in GetChildren())
		{
			if(child.Name == soundName)
			{
				return child.Playing;
			}
		}
		return false;
	}
	
	// Print the names of each sound in this controller 
	// and return the list.
	public List<String> PrintSounds() {
		List<String> sounds = new List<String>();
		foreach (AudioStreamPlayer sound in GetChildren()) {
			sounds.Add(sound.Name);
			GD.Print(sound.Name);
		}
		return sounds;
	}

	public int CountSounds() {
		return PrintSounds().Count;
	}
	
	// Change the volume by delta
	public bool ChangeVolume(int delta) {
		return SetVolume(volume + delta);
	}
	
	// Return the linear volume
	public int GetVolume() {
		return volume;
	}
	
	// Set linear volume and then db volume of children
	public bool SetVolume(int vol) {
		if (!VolumeInRange(vol)) return false;
		volume = vol;
		SetChildrenVolume(vol);
		return true;
	}

	// Stop a specific sound from playing
	public bool Stop(string sound)
	{
		foreach (AudioStreamPlayer othersound in GetChildren()) {
			if (sound == othersound.Name)
			{
				othersound.Stop();
				return true;
			}
		} 
		return false;
	}

	// Stop all sounds from playing
	public void StopAll()
	{
		foreach (AudioStreamPlayer sound in GetChildren()) sound.Stop();
	}
	
	// Set the decibel volume of each sound child
	private void SetChildrenVolume(int vol) {
		float db = VolumeToDb(vol);
		GD.Print("Setting DB to " + db);
		foreach (AudioStreamPlayer sound in GetChildren()) {
			sound.VolumeDb = db;
		}
	}
	
	// Convert a linear volume to decibels. If the volume is 0,
	// set decibels to the lowest value possible.
	private float VolumeToDb(float vol) {
		return (float)Mathf.LinearToDb((double)vol/80.0);
	}
	
	// Check that the volume is in range [0-100]
	private bool VolumeInRange(int vol) {
		return vol >= 0 && vol <= 100;
	}
}
