extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene5.tscn")

func test_zombie_gravity():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var zombie = test_scene.find_child("Zombie")
	var initialY = zombie.position.y

	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialY < zombie.position.y)
	
func test_skeleton_gravity():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var skeleton = test_scene.find_child("Skeleton")
	var initialY = skeleton.position.y

	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialY < skeleton.position.y)
	
func test_slime_gravity():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var slime = test_scene.find_child("Slime")
	var initialY = slime.position.y	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialY < slime.position.y)
	
func test_goblin_gravity():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Zombie").queue_free()
	
	var goblin = test_scene.find_child("Goblin")
	var initialY = goblin.position.y	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(initialY < goblin.position.y)
