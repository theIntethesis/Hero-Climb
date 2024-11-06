extends GutTest

var scene = load("res://[TL1] Ferris/tests/testScenes/test_scene3.tscn")
var zombieScene = load("res://[TL5] Jason/scenes/EnemyController.tscn")
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

func test_player_and_zombie():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	watch_signals(_player)
	var zC = zombieScene.instantiate()
	zC.spawns = [Vector2(70, -20)]
	var zombie = add_child_autofree(zC)
	zombie.SpawnEnemies()
	var enemy = zombie.get_children()
	watch_signals(enemy[0])
	await wait_for_signal(_player.PlayerHealthChange, 5)
	assert_signal_emit_count(enemy[0], "AttackPlayer", 1)
	assert_signal_emit_count(_player, "PlayerHealthChange", 1)

func test_fireball_and_zombie():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	var zC = zombieScene.instantiate()
	zC.spawns = [Vector2(70, -20)]
	var zombie = add_child_autofree(zC)
	zombie.SpawnEnemies()
	var enemy = zombie.get_children()
	watch_signals(enemy[0])
	var fireball = load("res://[TL1] Ferris/scenes/fireball.tscn").instantiate()
	fireball.position = Vector2(0, -10)
	fireball.Damage = 50
	add_child_autoqfree(fireball)
	assert_true(await wait_for_signal(enemy[0].TakeDamage, 5))
	assert_lt(enemy[0].Health, 100)

func test_attack_and_zombie():
	var pC = player.instantiate()
	pC.Class = 2
	_player = add_child_autofree(pC)
	var zC = zombieScene.instantiate()
	zC.spawns = [Vector2(70, -20)]
	var zombie = add_child_autofree(zC)
	zombie.SpawnEnemies()
	var enemy = zombie.get_children()
	watch_signals(enemy[0])
	await wait_seconds(.5)
	_sender.action_down("attack")\
		.action_up("attack")
	assert_true(await wait_for_signal(enemy[0].TakeDamage, 5))
	assert_lt(enemy[0].Health, 100)

func test_fighter_and_box():
	var pC = player.instantiate()
	pC.Class = 0
	var b = load("res://[TL1] Ferris/scenes/Wooden Box.tscn")
	var bC = b.instantiate()
	bC.position = Vector2(40, -8)
	var box = add_child_autoqfree(bC)
	add_child_autoqfree(pC)
	watch_signals(box)
	_sender.action_down("ability")\
		.action_up("ability")
	assert_true(await wait_for_signal(box.BoxBroken, 5))

func test_fireball_and_box():
	var pC = player.instantiate()
	pC.Class = 2
	var b = load("res://[TL1] Ferris/scenes/Wooden Box.tscn")
	var bC = b.instantiate()
	bC.position = Vector2(40, -8)
	var box = add_child_autoqfree(bC)
	add_child_autoqfree(pC)
	watch_signals(box)
	_sender.mouse_motion(Vector2.ZERO, Vector2(40, -8))
	_sender.action_down("ability")\
		.action_up("ability")
	assert_false(await wait_for_signal(box.BoxBroken, 5))
