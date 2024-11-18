# base_level.gd
# This is my Oral Exam prefab
extends Node2D
class_name Level

# Matrix representing how many of each piece type exist.
# Must be manually updated.
const PIECE_COUNTS = {"LY":2, "LC":3, "LN":2,
					  "CY":2, "CC":3, "CN":2,
					  "RY":2, "RC":3, "RN":2,}

@export var piece_folder = "res://"
# Naming convention for level pieces: piece_folder/[][][].tscn

# Layout map is used to determine what piece is drawn based on placement in level
# L is left, C is center, R is right
const LAYOUT_MAP = ["L","C","C","R"]

# Level layout determines the kind of level piece is used for each room
# Y is a route up, C is a route accessed by a class ability, N is no route, S is a shop
@export var level_layout = ["Y","C","N","S"]

@export var level_width = 464

# Randomizes level layout on ready
func _ready() -> void:
	randomize_level()

# randomize_level randomizes the level layout, then verifies the selected layour is valid
func randomize_level():
	var choices = ['Y','C','N']
	var level_place = 0
	while level_place<4:
		level_layout[level_place] = choices.pick_random()
		level_place += 1
	verify_level()

# verify_level adds a 'Y' to the level layout if one does not exist
# This ensures the level layout will generate a path forward
func verify_level():
	if not level_layout.has("Y"):
		level_layout[randi_range(0,3)] = "Y"

# add_shop randomly inserts an 'S' into the level layout, causing a shop to be generated
func add_shop():
	while not level_layout.has("S"):
		level_layout[randi_range(0,3)] = "S"
		verify_level()

# build_level randomly selects scenes to serve as each room base on the level layout
func build_level():
	var level_place = 0
	while level_place<4:
		var level_piece
		if level_layout[level_place]=="S":
			# Loads a shop if designated by the level layout
			level_piece = load(piece_folder 	#Directory containing level pieces
				+LAYOUT_MAP[level_place]
				+"Shop.tscn").instantiate()
		else:
			# Loads a level piece matching the level layout
			level_piece = load(piece_folder 	#Directory containing level pieces
				+LAYOUT_MAP[level_place]+level_layout[level_place] 	#Character in the level map
				+str(randi_range(1,PIECE_COUNTS[LAYOUT_MAP[level_place]+level_layout[level_place]])) 	#Number associated with level piece
				+".tscn").instantiate()
		
		# adds the level piece as a child
		add_child(level_piece)
		level_piece.position.x = level_place*level_width
		
		# gets enemies and collectables
		get_collectables(level_piece)
		get_enemies(level_piece)
		level_place += 1

# Finds collectable locations in a room, calls a function in the parent to handle them
func get_collectables(room):
	if get_parent().has_method("add_collectable"):
		var collectables = room.find_child("CollectableLocations")
		if collectables!=null:
			for point in collectables.get_children():
				get_parent().add_collectable(point.global_position)
				point.queue_free()
			collectables.queue_free()

# Finds enemy locations in a room, calls a function in the parent to handle them
func get_enemies(room):
	if get_parent().has_method("add_enemy"):
		var enemies = room.find_child("EnemyLocations")
		if enemies:
			for point in enemies.get_children():
				get_parent().add_enemy(point.global_position)
				point.queue_free()
			enemies.queue_free()

# Deletes the level
func delete_floor(_area : Area2D):
	queue_free()
