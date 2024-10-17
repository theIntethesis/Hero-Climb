extends GutTest

func test_level_gen():
	var scene = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child(scene)
	for i in range(0, 100000):
		if not scene.level_layout.has("Y"):
			print(i)
			assert_true(false)
			scene.queue_free()
			return
		scene.randomize_level()
	assert_true(true)
	scene.queue_free()

func test_floor_works():
	var scene = preload("res://[TL2] Taran/scenes/level_controller.tscn").instantiate()
	add_child(scene)
	var player = scene.find_child("Player")
	
	var gp = player.global_position.y
	for i in range (0, 100):
		player.velocity += Vector2.DOWN * 1000
		await get_tree().create_timer(0.01).timeout
	assert_lt(player.global_position.y, 0.0)
	scene.queue_free()
