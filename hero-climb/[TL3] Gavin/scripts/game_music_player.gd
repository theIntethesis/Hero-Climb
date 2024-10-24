# game_music_player.gd
# Gavin Haynes
# Began October 21, 2024

extends SoundController

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	super._init()
	set_volume(80)
	for sound in print_sounds():
		play(sound)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass
