# Gavin Haynes
# Hero Jump

# This script finds an inital average FPS, and then spawns fireballs
# until FPS is half of the initial, outputing the number.

extends Node

var fireballScene	# Ferris's fireball
var count			# temporary counter for number of frames
var initialFPS		# fps in the beginning
var FPS				# incremented every frame
var find_fps		# intial state to find normal fps
var fps_sum

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	fireballScene = preload("res://[TL3] Gavin/scenes/fireball2.tscn")
	spawn()
	count = 0
	find_fps = true
	initialFPS = 0;
	fps_sum = 0
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	count += 1
	fps_sum += delta
	print_debug(count * delta)
	
	if (find_fps):
		fps_sum += 1/delta;
		if (count >= 180):
			print_debug(str("FPS: ", fps_sum / 180))
			cleanup()

# instantiate a new fireball as child	
func spawn():
	var fireball = fireballScene.instantiate()
	add_child(fireball)

# delete all children fireballs and exit
func cleanup():
	for child in get_children():
		child.free()
	get_tree().quit()
