extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene3.tscn")

func test_zombie_attacks():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var zombie = test_scene.find_child("Zombie")
	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(zombie.HasAttacked == true)
	
func test_skeleton_attacks():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var skeleton = test_scene.find_child("Skeleton")
	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(skeleton.HasAttacked == true)
	
func test_slime_attacks():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Zombie").queue_free()
	test_scene.find_child("Goblin").queue_free()
	
	var slime = test_scene.find_child("Slime")
	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(slime.HasAttacked == true)
	
func test_goblin_attacks():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	
	test_scene.find_child("Skeleton").queue_free()
	test_scene.find_child("Slime").queue_free()
	test_scene.find_child("Zombie").queue_free()
	
	var goblin = test_scene.find_child("Goblin")
	
	await get_tree().physics_frame
		# Simulate 5 seconds of physics
	for i in range(3 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
		
	assert_true(goblin.HasAttacked == true)
