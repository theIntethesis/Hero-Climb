// SoundController.cs
// Gavin Haynes
// October 29, 2024
// CS383 Software Engineering
// Base class for sound controllers to handle playing sounds and changing volume.

using Godot;
using System;
using System.Collections.Generic;

public partial class SoundController : Node
{
	private int volume = 100;	// Set to 100 because children are at 0db.
	
	// Play a sound using its name
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
	
	// Get a list of all playable sounds
	public List<String> listSounds() {
		List<String> sounds = new List<String>();
		foreach (AudioStreamPlayer sound in GetChildren()) {
			sounds.Add(sound.Name);
		}
		return sounds;
	}
	
	// Modify the volume by delta
	public bool changeVolume(int delta) {
		return setVolume(volume+delta);
	}
	
	// Get the linear volume
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
	
	// Set the volume of each sound child in decibles 
	private void setChildrenVolume(int vol) {
		float db = volumeToDb(vol);
		foreach (AudioStreamPlayer sound in GetChildren()) {
			sound.VolumeDb = db;
		}
	}
	
	// Convert a linear volume to decibels.
	private float volumeToDb(int vol) {
		return Mathf.LinearToDb(vol/100);
	}
	
	// Check that the volume is in range [0-100]
	private bool checkVolume(int vol) {
		return vol >= 0 && vol <= 100;
	}
}
