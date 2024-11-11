extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene7.tscn")

func test_dynamic_binding():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)

	# Find the Zombie in the test scene
	var zombie = test_scene.find_child("Zombie")
	var skeleton = test_scene.find_child("Skeleton")
	var slime = test_scene.find_child("Slime")
	var goblin = test_scene.find_child("Goblin")
	zombie.SetupEnemy()
	skeleton.SetupEnemy()
	slime.SetupEnemy()
	goblin.SetupEnemy()

	# Simulate 10 seconds of physics
	for i in range(5 * 60):  # Assuming 60 FPS
		await get_tree().physics_frame
	
	var zSpeed = zombie.Speed
	var skelSpeed = skeleton.Speed
	var slimSpeed = slime.Speed
	var gobSpeed = goblin.Speed
	assert_true(zSpeed != skelSpeed and zSpeed != slime.Speed and zSpeed != gobSpeed)
	assert_true(skelSpeed != slimSpeed and skelSpeed != gobSpeed)
	assert_true(slimSpeed != gobSpeed)
