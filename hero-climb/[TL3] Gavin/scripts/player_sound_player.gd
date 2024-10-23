# player_sound_controller.gd
# Gavin Haynes
# Began October 17, 2024
# Play and manage player sound.

extends Node2D

var _volume: int		# _ prefix makes variable private

# Play a sound using the name of the sound.
func play(soundName: String) -> bool:
	match soundName:		# case statement, auto break on match
		"attack":	$Attack.play()
		"jump":		$Jump.play()
		"damaged":	$PlayerDamaged.play()
		"walk":		$Walking.play()
		_:			return false
	return true

# Add or subtract from the current volume by delta
func change_volume(delta: int) -> bool:
	var result = _volume + delta
	if (check_volume(result)):	# check volume in range after change
		set_volume(result)
		return true;
	else:	
		return false;

# Set the volume to a value int [0-100] change volume of 
# all children sounds.
func set_volume(volume: int) -> bool:
	if (check_volume(volume)):	# check bounds
		_volume = volume
		_set_child_volume(_volume)
		return true
	else:
		return false

# Check volume bounds [0-100] inclusive
func check_volume(volume: int) -> bool:
	return true if volume >= 0 && volume <= 100 else false

# Return the volume
func get_volume() -> int:
	return _volume

# Convert a value from 0-1 to a db value
# cast to float to preserve info
func volumeToDb(volume: int) -> int:
	return linear_to_db(float(_volume)/100.0)

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	set_volume(80)
	for child in get_children():
		print(child.name)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

# Set the volume of all children (sounds)
func _set_child_volume(volume: int) -> void:
	for child in get_children():
		child.volume_db = volumeToDb(volume)
