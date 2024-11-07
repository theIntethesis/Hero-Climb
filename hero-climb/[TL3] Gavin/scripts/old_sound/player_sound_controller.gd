# player_sound_controller.gd
#
# Gavin Haynes, Your Name
# Began October 21, 2024
#
# Sound interface for the player controller. Extends the base sound controller,
# which defines functionality with playing sounds and modifying volume.
# See base_sound_controller in Gavin's scripts for source.
#
# Intended Usage (ex):
# $PlayerSoundController.play("SoundName")
# $PlayerSoundController.set_volume(80)
# $PlayerSoundController.change_volume(10)

extends SoundController

var hero_class: String

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	super._init()
	set_hero_class("Rogue")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

# Play a player sound. If playing an attack, play the right sound for the 
# current hero class
func play(sound: String) -> bool:
	if (sound == "Attack"):
		sound = str(hero_class, "Attack")
	return super.play(sound)

# Set the name of your hero class. Options are Rogue, Wizard, and Fighter.
# Prefixes the hero name to "Attack" to play the right sound.
func set_hero_class(hero: String) -> bool:
	if (hero == "Rogue" || hero == "Wizard" || hero == "Fighter"):
		hero_class = hero
		return true
	else:
		hero_class = "Rogue"
		return false
