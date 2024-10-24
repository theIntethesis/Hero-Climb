# game_music_player.gd
# Gavin Haynes, Your Name
# Began October 21, 2024
#
# Sounds: Main, Game, Death
#
# Intended Usage (ex):
# $GameSoundController.play("Main")
# $GameSoundController.set_volume(80)
# $GameSoundController.change_volume(10)

extends SoundController

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	super._init()	# init soundController
	set_volume(80)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

# Play a game soundtrack and stop the other soundtracks
func play(song: String) -> bool:
	stop_all()
	return super.play(song)
