# hud_sound_controller.gd
#
# Gavin Haynes
# Started October 24, 2024
#
# Sound Controller script to handle any HUD sounds.

extends SoundController

func _ready() -> void:
	super._init()
	for sound in print_sounds():
		play(sound)
	
func _process(delta: float) -> void:
	pass
