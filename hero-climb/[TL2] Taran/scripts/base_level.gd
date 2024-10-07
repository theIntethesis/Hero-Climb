extends Node2D
class_name Level

const PIECE_COUNTS = {"LY":2, "LC":2, "LN":2,
					"CY":2, "CC":2, "CN":2,
					"RY":2, "RC":2, "RN":2,}

# L is left, C is center, R is right
const LAYOUT_MAP = ["L","C","C","R"]

# Y is a route up, C is a class route, N is no route, S is a shops
var level_layout = ["Y","C","N","C"]

func _ready():
	build_level()

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
		level_piece.global_position.x = level_place*464
		level_place += 1
