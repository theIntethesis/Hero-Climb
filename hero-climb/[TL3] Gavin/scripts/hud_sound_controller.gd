extends SoundController

func _ready() -> void:
	super._init()
	for sound in print_sounds():
		play(sound)
	
func _process(delta: float) -> void:
	pass
