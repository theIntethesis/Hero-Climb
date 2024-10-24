extends GutTest

var scene = load("res://[TL1] Ferris/tests/testScenes/test_scene3.tscn")
var zombieScene = load("res://[TL5] Jason/scenes/zombie.tscn")
var player = load("res://[TL1] Ferris/scenes/PlayerController.tscn")

var _level = null
var _player = null
var _sender = InputSender.new(Input)

func before_each():
	_level = add_child_autoqfree(scene.instantiate())
	await(wait_seconds(.25))

func after_each():
	_sender.release_all()
	_sender.clear()

func test_lava():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	watch_signals(_player)
	add_child_autofree(load("res://[TL2] Taran/scenes/rising_lava.tscn").instantiate())
	assert_true(await wait_for_signal(_player.IsDead, 5))

func test_zombie():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	watch_signals(_player)
	var zC = zombieScene.instantiate()
	zC.position = Vector2(10, 500)
	var zombie = add_child_autofree(zC)
	_player = add_child_autofree(pC)
	assert_true(await wait_for_signal(_player.Injury, 5))

func test_fireball():
	var zombie = add_child_autoqfree(zombieScene.instantiate())
	var fireball = load("res://[TL1] Ferris/scenes/fireball.tscn").instantiate()
	fireball.position = Vector2(10, 0)
	add_child_autoqfree(fireball)
	await wait_seconds(.25)
	assert_lt(zombie.health, 100)
