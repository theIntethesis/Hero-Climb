extends GutTest


func test_input():
	var Scene = load("res://[TL1] Ferris/scenes/PlayerController.tscn")
	var FloorScene = load("res://[TL1] Ferris/scenes/floor.tscn")
	var instance = Scene.instantiate()
	var floorInstance = FloorScene.instantiate()
	add_child(instance)
	add_child(floorInstance)
	var Player = get_node("Player")
	var cam = Camera2D.new()
	cam.offset = Vector2(30, 0)
	Player.add_child(cam)
	
	wait_seconds(2)
	var Sender = InputSender.new(Player).wait(1)
	
	Sender.action_down("jump")
	print(Player.get_velocity())
	await(Sender.idle)
	assert_true(Player.get_velocity() < Vector2.ZERO)
	

func test_ex():
	assert_eq(1, 1)
	
