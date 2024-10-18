extends Node2D

var childList

# enum {ATTACK, JUMP, WALK, DAMAGE}

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	childList = get_children()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

# Play a 
func play(sound):
	childList[sound].play()
