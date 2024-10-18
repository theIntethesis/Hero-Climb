# player_sound_controller.gd
# Gavin Haynes
# Began October 17, 2024

# Description
# Play and manage player sounds. 

extends Node2D

var _volume: int

# Play a sound
func play(soundName: String) -> bool:
	match soundName:
		"attack":
			$Attack.play()
			return true;
		"jump":
			$Jump.play()
			return true;
		"damaged":
			$PlayerDamaged.play()
			return true;
		"walk":
			$Walking.play()
			return true;
		_:
			return false;

# Add or subtract from the current volume by delta
func changeVolume(delta: int) -> bool:
	var result = _volume + delta
	if (result >= 0 && result <= 100):
		_volume = result
		return true;
	else:
		return false;

# Set the volume to a value int [0-100]
func setVolume(volume: int) -> bool:
	if (volume >= 0 && volume <= 100):
		_volume = volume
		return true
	else:
		return false

# Return the volume
func getVolume() -> int:
	return _volume

# Convert a value from 0-1 to a db value
func volumeToDb(volume: int) -> int:
	return linear_to_db(volume/100.0)

func checkVolume(volume: int) -> bool:
	return false

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	setVolume(80)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

func _set_child_volume(volume: int) -> void:
	for child in get_children():
		child.volume_db = volumeToDb(volume)
