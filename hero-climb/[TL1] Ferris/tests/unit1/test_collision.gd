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

func test_lava_and_player():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	watch_signals(_player)
	add_child_autofree(load("res://[TL2] Taran/scenes/rising_lava.tscn").instantiate())
	assert_true(await wait_for_signal(_player.PlayerDeath, 5))

func test_player_from_zombie():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	watch_signals(_player)
	var zC = zombieScene.instantiate()
	zC.position = Vector2(70, -20)
	var zombie = add_child_autofree(zC)
	assert_true(await wait_for_signal(_player.Injury, 5))

func test_zombie_from_player():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	var zC = zombieScene.instantiate()
	zC.position = Vector2(70, -20)
	var zombie = add_child_autofree(zC)
	watch_signals(zombie)
	assert_true(await wait_for_signal(zombie.AttackPlayer, 5))

func test_fireball_and_zombie():
	var zC = zombieScene.instantiate()
	zC.position = Vector2(70, -20)
	var zombie = add_child_autoqfree(zC)
	var fireball = load("res://[TL1] Ferris/scenes/fireball.tscn").instantiate()
	fireball.position = Vector2(0, -10)
	fireball.Damage = 50
	add_child_autoqfree(fireball)
	assert_true(await wait_for_signal(zombie.TakeDamage, 5))
	assert_lt(zombie.Health, 100)

func test_attack_and_zombie():
	var _sender = InputSender.new(Input)
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	var zC = zombieScene.instantiate()
	zC.position = Vector2(70, -20)
	var zombie = add_child_autofree(zC)
	watch_signals(zombie)
	await wait_seconds(.5)
	_sender.action_down("attack")\
		.action_up("attack")
	assert_true(await wait_for_signal(zombie.TakeDamage, 5))
	assert_lt(zombie.Health, 100)
