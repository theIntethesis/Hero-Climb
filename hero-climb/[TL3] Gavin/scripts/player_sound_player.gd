# player_sound_controller.gd
# Gavin Haynes
# Began October 21, 2024

extends SoundController

enum HeroClass {ROGUE, WIZARD, FIGHTER}

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	super._init()
	set_volume(80)
	for sound in print_sounds():
		play(sound)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

func set_hero_class(name: HeroClass) -> bool:
	match name:
		HeroClass.ROGUE:
			pass
		HeroClass.WIZARD:
			pass
		HeroClass.FIGHTER:
			pass
		_:
			return false
	return true
