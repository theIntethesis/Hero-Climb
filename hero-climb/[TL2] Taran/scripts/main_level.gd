extends Node2D

const FLOOR_HEIGHT = 223

func _ready():
	var floors = [preload("res://[TL2] Taran/scenes/tower pieces/tf_1.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tf_2.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tf_3.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tf_4.tscn"),
		preload("res://[TL2] Taran/scenes/tower pieces/tf_5.tscn")]
	
	var level = 1
	while( level < 10):
		var new_floor = floors[randi()%floors.size()].instantiate()
		add_child(new_floor)
		new_floor.global_position.y -= level*FLOOR_HEIGHT
		level += 1
