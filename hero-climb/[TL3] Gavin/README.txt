Gavin Haynes
CS383 Software Engineering
Team Lead 3: Quality Assurance Manager
Team Tappa Tappa Keyboard

                        Hero Climb Sound Interface Package


Overview:
 
    A sound interface is necessary in games to provide ques to the player, alerting
in-game events and enhancing immersion. Our game, Hero Climb, consists of several 
sound controllers which are responsible for one area of the game, comprised of:
    * PlayerSoundController, player sound effects,
    * GameSoundController, soundtrack,
    * HUDSoundController, button interaction,
    * WorldSoundController, world events and sound effects,
    * and EnemySoundController, enemy sound effects.
Additionally there is MainSoundController, which controls the volume of all SoundControllers.


Setup:

    This guide assumes that you have an existing game in GoDot. These tools are all written in C#.
Each SoundController is designed to operate as a child of whatever thing you want to give sound,
with this sound interface coming preinstalled with a complete soundtrack and sound suite already. 
To integrate sound modeules, for example, if your scene tree resembles:
* Node
    * Player
    * World
    * EnemyController
    * HUD
Instantiate each appropriate SoundController scene, would resemble:
* Node
    * Player
        * PlayerSoundController
    * World
        * WorldSoundController
    * EnemyController
        * EnemySoundController
    * HUD
        * HUDSoundController
You don't need to use every provided controller, these are just defined examples.


Usage:

    Now, to play sounds, each SoundController must be appropriately connected to the desired scene.
Suppose some script called PlayerController which is attached to Player as above. To connect
to PlayerSoundController (or your custom SoundController), in PlayerController:

public partial class PlayerController : Node
{
    static HUDSoundController SoundPlayer;
    
	public override void _Ready()
	{
		SoundPlayer = GetNode<HUDSoundController>("HUDSoundController");	// or name of associated SoundPlayer

Now, the sound is accessible within your script. The base functionality of a SoundController is:
    * new() -> default constructor
    * bool Play(string) -> play a sound with it's name
    * bool Stop(string) -> stop a sound
    * List<String> PrintSounds() -> print playable sounds
    * int GetVolume() -> returns the volume from 0 to 100
    * bool SetVolume() -> sets the volume
    * bool ChangeVolume(int) -> change the volume by a value
    * void StopAll() -> stop all sounds
    * int CountSounds() -> get the number of playable sounds.
Additionally, the SoundController base class handles interaction with GoDot AudioStreamPlayer objects
with the private member VolumeToDb(float) to convert a linear volume scale [0-100] to GoDot's 
[-80-0] decibel range.


Example Usage of HUDSoundController:

public partial class MyHudController : Node
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
}

