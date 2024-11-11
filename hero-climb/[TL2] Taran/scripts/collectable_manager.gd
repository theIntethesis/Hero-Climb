extends Node2D
class_name collectable_manager

func instantiate_collectable(point : Vector2, type):
	# 20% chance for a no collectable to be generated
	# 10% chance for a healing item to be generated
	# 70% chance for a coin to be generated
	if type=='r':
		var rand = randi_range(1, 10)
		if rand>3:
			const PICKUP = preload("res://[TL2] Taran/scenes/pickup_item.tscn")
			var new_collectable = PICKUP.instantiate()
			new_collectable.global_position = point
			add_child(new_collectable)
			new_collectable.SetAsCoin()
		elif rand==3:
			const PICKUP = preload("res://[TL2] Taran/scenes/pickup_item.tscn")
			var new_collectable = PICKUP.instantiate()
			new_collectable.global_position = point
			add_child(new_collectable)
			new_collectable.SetAsHeal()
	elif type=='c':
		const PICKUP = preload("res://[TL2] Taran/scenes/pickup_item.tscn")
		var new_collectable = PICKUP.instantiate()
		new_collectable.global_position = point
		add_child(new_collectable)
		new_collectable.SetAsCoin()
	elif type=='h':
		const PICKUP = preload("res://[TL2] Taran/scenes/pickup_item.tscn")
		var new_collectable = PICKUP.instantiate()
		new_collectable.global_position = point
		add_child(new_collectable)
		new_collectable.SetAsHeal()
