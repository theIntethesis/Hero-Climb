# sound_controller.gd
# Gavin Haynes
# October 21, 2024
# Base class for all Sound Controllers except Main

extends Node

class_name SoundController

var _volume: int
var _sounds: Array	# list of child nodes

# Load sounds and set the volume
func _init() -> void:
	_load_sounds()
	set_volume(80)

# Play a sound
func play(sound_name: String) -> bool:
	for sound in _sounds:
		if sound.name == sound_name:
			sound.play()
			return true
	return false

# Print all the sounds a SoundController can play and return the list.
func print_sounds() -> Array:
	var name_list = []
	for sound in _sounds:
		name_list.push_back(String(sound.name))
	print(name_list)
	return name_list

# Add or subtract from the current volume by delta
func change_volume(delta: int) -> bool:
	var result = _volume + delta
	if (check_volume(result)):	# check volume in range after change
		set_volume(result)
		return true;
	else:	
		return false;

# Return the linear volume
func get_volume() -> int:
	return _volume

# Set the linear volume, which is stored in the base class. The actual volume
# in db is converted and then passed to all the child sounds
func set_volume(vol: int) -> bool:
	if (check_volume(vol)): 
		_volume = vol
		_set_children_db(_volume)
		return true
	else:
		return false

# Check volume bounds [0-100] inclusive
func check_volume(volume: int) -> bool:
	return true if volume >= 0 && volume <= 100 else false

# Convert a value from 0-1 to a db value
# cast to float to preserve info
func volumeToDb(volume: int) -> int:
	return linear_to_db(float(_volume)/100.0)
	
func _load_sounds() -> void:
	_sounds = get_children()

func _set_children_db(volume: int) -> void:
	for sound in _sounds:
		sound.volume_db = volumeToDb(volume)
