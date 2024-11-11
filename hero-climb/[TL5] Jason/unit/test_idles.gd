extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene4.tscn")

func test_zombie_idles():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var zombie = test_scene.find_child("Zombie")
	var initialX = zombie.position.x

	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialX == zombie.position.x)
	
func test_skeleton_idles():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var skeleton = test_scene.find_child("Skeleton")
	var initialX = skeleton.position.x

	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialX == skeleton.position.x)
	
func test_slime_idles():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var slime = test_scene.find_child("Slime")
	var initialX = slime.position.x	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialX == slime.position.x)
	
func test_goblin_idles():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Zombie").queue_free()
	
	var goblin = test_scene.find_child("Goblin")
	var initialX = goblin.position.x	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialX == goblin.position.x)
