extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene6.tscn")

func test_zombie_detection():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var zombie = test_scene.find_child("Zombie")
	var player = test_scene.find_child("Player")

	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(floor(player.position.x) == floor(zombie.position.x))
	
func test_skeleton_detection():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var skeleton = test_scene.find_child("Skeleton")
	var player = test_scene.find_child("Player")

	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(floor(player.position.x) == floor(skeleton.position.x))
	
func test_slime_detection():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var slime = test_scene.find_child("Slime")
	var player = test_scene.find_child("Player")
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(floor(player.position.x) == floor(slime.position.x))
	
func test_goblin_detection():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Zombie").queue_free()
	
	var goblin = test_scene.find_child("Goblin")
	var player = test_scene.find_child("Player")	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(floor(player.position.x) == floor(goblin.position.x))
