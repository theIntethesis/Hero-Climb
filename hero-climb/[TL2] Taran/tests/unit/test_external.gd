extends GutTest

func test_floor_works():
	var scene = preload("res://[TL2] Taran/scenes/level_controller.tscn").instantiate()
	add_child_autofree(scene)
	var player = scene.find_child("Player")
	
	var gp = player.global_position.y
	for i in range (0, 100):
		player.velocity += Vector2.DOWN * 1000
		await get_tree().create_timer(0.01).timeout
	assert_lt(player.global_position.y, 0.0)

func test_floor_marker_detects_player():
	var scene = preload("res://[TL2] Taran/scenes/level_controller.tscn").instantiate()
	add_child_autofree(scene)
	
	var floor_marker = scene.find_child("FloorMarker")
	var player = scene.find_child("Player")
	
	var old_level = scene.current_level
	floor_marker.find_child("CollisionShape2D").global_position = player.global_position
	var old_position = floor_marker.find_child("CollisionShape2D").global_position
	
	await get_tree().create_timer(0.1).timeout
	
	assert_gt(scene.current_level, old_level)
	assert_lt(floor_marker.find_child("CollisionShape2D").global_position, old_position)
