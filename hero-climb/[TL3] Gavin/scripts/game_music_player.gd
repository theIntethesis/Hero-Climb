# Gavin Haynes
# October 17, 2024

# Play the main game music.
# Callbacks control music playing based on signals sent from
# either the HUD or the game controller.

# !!!CHANGE THE NAMES OF THE CALLBACK FUNCTIONS ACCORDING TO WHATEVER 
# YOU CHOSE TO NAME YOUR SIGNAL!!!

extends Node

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

# Play the main menu music
func _on_enter_main_menu():
	stop_all_music()
	$MainMenuMusic.play()

# Play the game music soundtrack
func _on_enter_game():
	stop_all_music()
	$GameMusic.play()

# Play the death sound
func _on_enter_death():
	stop_all_music()
	$DeathSound.play()
	
# Stop all ther music streams
func stop_all_music():
	for child in get_children(): 
		child.stop()
