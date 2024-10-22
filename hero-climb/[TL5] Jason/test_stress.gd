extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene1.tscn")
var ZombieScene = preload("res://[TL5] Jason/scenes/Zombie.tscn")

func test_zombie_fps_drop():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	var num_zombies = 0
	var fps = 0.0
	
	# Allow 10 seconds for average frames to stabilize
	for i in range(60*5):
		await get_tree().physics_frame
	
	fps = Engine.get_frames_per_second()
	
	# Spawn zombies until FPS drops below 10
	while fps >= 10:
		var zombie = ZombieScene.instantiate()
		test_scene.add_child(zombie)
		num_zombies += 1
		
		await get_tree().physics_frame
		fps = Engine.get_frames_per_second()
	
	print("FPS dropped below 10 after spawning ", num_zombies, " zombies.")
	assert_true(fps < 10, "FPS should be below 10")
