extends Node2D

var current_level = 1

func _ready() -> void:
	var i = 0
	while(i<20):
		add_new_level()
		i += 1

func add_new_level():
	var new_level = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child(new_level)
	new_level.position = Vector2(0,current_level*-192)
	new_level.build_level()
	current_level += 1
