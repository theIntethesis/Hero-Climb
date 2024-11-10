extends GutTest

func test_level_gen():
	var scene = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child_autofree(scene)
	for i in range(0, 10000):
		assert_true(scene.level_layout.has("Y"))
		scene.randomize_level()

func test_add_shop():
	var scene = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child_autofree(scene)
	for i in range(0, 100000):
		scene.add_shop()
		assert_true(scene.level_layout.has("S"))
		scene.randomize_level()

func test_spawn_collectable():
	var scene = preload("res://[TL2] Taran/scenes/collectable_manager.tscn").instantiate()
	add_child_autofree(scene)
	scene.instantiate_collectable(Vector2(0,0), 'c')
	scene.instantiate_collectable(Vector2(0,0), 'h')
	scene.instantiate_collectable(Vector2(0,0), 'r')
	assert_true(scene.get_child_count()==2 || scene.get_child_count()==3)

func test_lava_deletes_floor():
	var floor = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child_autofree(floor)
	var lava = preload("res://[TL2] Taran/scenes/rising_lava.tscn").instantiate()
	add_child_autofree(lava)
	lava.global_position = floor.find_child("Area2D").find_child("CollisionShape2D").global_position
	lava.Speed = 50
	await get_tree().create_timer(0.25).timeout
	assert_freed(floor)

func test_add_level():
	var scene = preload("res://[TL2] Taran/scenes/level_controller.tscn").instantiate()
	add_child_autofree(scene)
	var old_level = scene.current_level
	scene.add_new_level()
	assert_gt(scene.current_level, old_level)
