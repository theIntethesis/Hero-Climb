extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene2.tscn")

func test_skeleton_shoot():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	var skeleton = test_scene.find_child("Skeleton")
	test_scene.find_child("Goblin").queue_free()
	
	# Simulate 5 seconds of physics
	for i in range(5 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
	
	assert_true(skeleton.HasAttacked)
	
func test_slime_split():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	var slime = test_scene.find_child("Slime")
	slime.SpawnSlime()
	# Simulate 5 seconds of physics
	for i in range(5 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
	
	assert_true(slime.HasSlimed)

func test_goblin_jump():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	var skeleton = test_scene.find_child("Skeleton")
	skeleton.queue_free()
	var goblin = test_scene.find_child("Goblin")
	var goblinInitialY = goblin.position.y
	
	# Simulate 5 seconds of physics
	for i in range(5 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
	
	assert_true(goblin.position.y < goblinInitialY)
