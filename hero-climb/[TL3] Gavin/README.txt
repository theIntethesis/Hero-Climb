Gavin Haynes
November 7, 2024

            Hero Climb: Guide to playing and managing sound.

Overview:
    All sound controllers in Hero Climb share similar functionality, which include
playing sounds, printing available sounds, changing the volume, etc. There is one
abstract base class SoundController which is implemented as GameSoundController, 
HUDSoundController, PlayerSoundController, and EnemySoundController.

Setup:
    To add sound to your scene, instantiate the necessary (*)SoundController
as a child. Now in your main script, the SoundController can be interfaced
by adding:

    GameSoundController SoundPlayer = GetNode<GameSoundController>("GameMusicPlayer");

