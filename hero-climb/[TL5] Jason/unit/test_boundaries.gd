extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene1.tscn")

func test_zombie_wall_collision():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)

	# Find the Zombie in the test scene
	var zombie = test_scene.find_child("Zombie")

	# Record the initial x position
	var initial_x = zombie.position.x

	# Simulate 5 seconds of physics
	for i in range(5 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame

	# Check if the Zombie has gone through the wall
	assert_gt(zombie.position.x, -218, "Zombie should not have passed through the wall")
	
	# Check if the Zombie has moved at all
	assert_ne(zombie.position.x, initial_x, "Zombie should have attempted to move")
	
func test_zombie_ledge_balance():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)

	# Find the Zombie in the test scene
	var zombie = test_scene.find_child("Zombie2")

	# Record the initial x position
	var initial_y = zombie.position.y
	var initial_x = zombie.position.x
	
	# Simulate 5 seconds of physics
	for i in range(5 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame

	# Check if the Zombie has gone through the wall
	assert_gt(zombie.position.y, initial_y-1, "Zombie should not have fallen off the platform")
	
	# Check if the Zombie has moved at all
	assert_ne(zombie.position.x, initial_x, "Zombie should have attempted to move")
