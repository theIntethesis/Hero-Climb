extends Node2D

var childList

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	childList = get_children()
	play(-1)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

# Play a 
func play(sound):
	assert(sound > 0 && sound < childList.size(), 
		str("PlayerSoundPlayer: Attempted to play an invalid sound: ", sound))
	childList[sound].play()
