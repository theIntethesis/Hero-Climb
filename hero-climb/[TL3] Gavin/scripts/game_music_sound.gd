# Gavin Haynes
# October 17, 2024
# Game Music Sound Player

# Controls playing songs from the main soundtrack

extends AudioStreamPlayer

var inMainMenu

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	inMainMenu = true

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if (inMainMenu):
		seek(0)
