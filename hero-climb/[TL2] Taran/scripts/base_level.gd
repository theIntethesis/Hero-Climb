extends Node2D
class_name Level

const PIECE_COUNTS = {"LY":0, "LC":0, "LN":0,
					"CY":2, "CC":2, "CN":2,
					"RY":0, "RC":0, "RN":0,}

# L is left, C is center, R is right
const LAYOUT_MAP = ["L","C","C","R"]

# Y is a route up, C is a class route, N is no route, S is a shops
var level_layout = ["Y","C","N","S"]

func _ready():
	build_level()

func build_level():
	var level_place = 0
	while level_place<4:
		if level_layout[level_place]=="S":
			print("res://[TL2] Taran/scenes/tower pieces/"
				+LAYOUT_MAP[level_place]
				+"Shop.tscn")
		else:
			print("res://[TL2] Taran/scenes/tower pieces/"
				+LAYOUT_MAP[level_place]+level_layout[level_place]
				+str(randi_range(1,PIECE_COUNTS[LAYOUT_MAP[level_place]+level_layout[level_place]]))
				+".tscn")
		level_place += 1
