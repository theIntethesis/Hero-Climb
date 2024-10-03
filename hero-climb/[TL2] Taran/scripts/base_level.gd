extends Node2D
class_name Level

const PIECE_COUNTS = {"LY":0, "LC":0, "LN":0,
					"CY":0, "CC":0, "CN":0,
					"RY":0, "RC":0, "RN":0,}

const LAYOUT_MAP = ["L","C","C","R"]

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
				+str(randi_range(0,PIECE_COUNTS[LAYOUT_MAP[level_place]+level_layout[level_place]]))
				+".tscn")
		level_place += 1
