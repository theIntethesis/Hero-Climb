extends Node2D
class_name collectable_manager

func instantiate_collectable(point : Vector2):
	const PICKUP = preload("res://[TL2] Taran/scenes/pickup_item.tscn")
	var new_collectable = PICKUP.instantiate()
	add_child(new_collectable)
	new_collectable.global_position = point
