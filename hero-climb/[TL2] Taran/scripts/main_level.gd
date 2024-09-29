extends Node2D

const FLOOR_HEIGHT = 223

func _ready():
	var floors = [preload("res://[TL2] Taran/scenes/tower pieces/tp1.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tp2.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tp3.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tp_4.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tp_5.tscn")]
	
	var level = 1
	while( level < 5):
		var new_floor = floors[randi()%floors.size()].instantiate()
		add_child(new_floor)
		new_floor.global_position.y -= level*FLOOR_HEIGHT
		level += 1
