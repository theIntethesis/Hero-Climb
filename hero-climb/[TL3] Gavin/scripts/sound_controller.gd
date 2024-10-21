# sound_controller.gd
# Gavin Haynes
# October 21, 2024
# Base class for all Sound Controllers except Main

extends Node

class_name SoundController

var _volume: int
var _sounds: Array	# list of child nodes

var path_to_sounds: Array

# Initializer
func _init() -> void:
	_sounds = get_children()
	set_volume(80)

# Play a sound
func play(sound_name: String) -> bool:
	for sound in _sounds:
		if sound.name == sound_name:
			sound.play()
			return true
	return false
	
func load_sounds() -> void:
	_sounds = get_children()

# Add or subtract from the current volume by delta
func change_volume(delta: int) -> bool:
	var result = _volume + delta
	if (check_volume(result)):	# check volume in range after change
		set_volume(result)
		return true;
	else:	
		return false;

# Return the volume
func get_volume() -> int:
	return _volume

func set_volume(vol: int) -> bool:
	return true

# Check volume bounds [0-100] inclusive
func check_volume(volume: int) -> bool:
	return true if volume >= 0 && volume <= 100 else false

# Convert a value from 0-1 to a db value
# cast to float to preserve info
func volumeToDb(volume: int) -> int:
	return linear_to_db(float(_volume)/100.0)
