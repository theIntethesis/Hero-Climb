extends Node2D
class_name Level

# Matrix representing how many of each piece type exist.
# Must be manually updated.
const PIECE_COUNTS = {"LY":2, "LC":2, "LN":2,
					"CY":2, "CC":2, "CN":2,
					"RY":2, "RC":2, "RN":2,}

# L is left, C is center, R is right
const LAYOUT_MAP = ["L","C","C","R"]

# Y is a route up, C is a class route, N is no route, S is a shops
@export var level_layout = ["Y","C","N","C"]

func _ready() -> void:
	randomize_level()

func randomize_level():
	var choices = ['Y','C','N']
	var level_place = 0
	while level_place<4:
		level_layout[level_place] = choices.pick_random()
		level_place += 1
		verify_level()

func verify_level():
	if not level_layout.has("Y"):
		level_layout[randi_range(0,3)] = "Y"

func add_shop():
	while not level_layout.has("S"):
		level_layout[randi_range(0,3)] = "S"
		verify_level()

func build_level():
	var level_place = 0
	while level_place<4:
		var level_piece
		if level_layout[level_place]=="S":
			level_piece = load("res://[TL2] Taran/scenes/tower pieces/"
				+LAYOUT_MAP[level_place]
				+"Shop.tscn").instantiate()
		else:
			level_piece = load("res://[TL2] Taran/scenes/tower pieces/"
				+LAYOUT_MAP[level_place]+level_layout[level_place]
				+str(randi_range(1,PIECE_COUNTS[LAYOUT_MAP[level_place]+level_layout[level_place]]))
				+".tscn").instantiate()
		
		add_child(level_piece)
		level_piece.position.x = level_place*464
		
		get_collectables(level_piece)
		#get_enemies(level_piece)
		level_place += 1

func get_collectables(room):
	var collectables = room.find_child("CollectableLocations")
	if collectables!=null:
		for point in collectables.get_children():
			get_parent().add_collectable(point.global_position)
			point.queue_free()
		collectables.queue_free()

func get_enemies(room):
	var enemies = room.find_child("EnemyLocations")
	if enemies:
		for point in enemies.get_children():
			get_parent().add_enemy(point.global_position)
			point.queue_free()
		enemies.queue_free()
