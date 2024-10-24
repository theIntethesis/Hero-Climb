# player_sound_controller.gd
# Gavin Haynes
# Began October 21, 2024
# Sound interface for the player controller. Extends the base sound controller,
# which defines functionality with playing sounds and modifying volume.
# See base_sound_controller in Gavin's scripts for source.

extends SoundController

var hero_class: String

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	super._init()
	set_volume(80)
	for sound in print_sounds():
		play(sound)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

func set_hero_class(name: String) -> bool:
	match name:
		"Rogue":
			pass
		"Wizard":
			pass
		"Fighter":
			pass
		_:
			return false
	return true
