extends GutTest

var scene = load("res://[TL1] Ferris/tests/testScenes/test_scene1.tscn")
var playerScene = load("res://[TL1] Ferris/scenes/WizardSprite.tscn")

var _level = null
var _player = null
var _sender = InputSender.new(Input)

func cleanup():
	for child in get_children():
		child.queue_free()

func before_each():
	_level = add_child_autofree(scene.instantiate())
	_player = add_child_autofree(playerScene.instantiate())
	PlayerGlobal.SetPlayer(_player)
	await(wait_seconds(.25))

func after_each():
	_sender.release_all()
	_sender.clear()

func test_health():
	watch_signals(_player)
	_player.Health = PlayerGlobal.GetSetPlayerMaxHealth(25)
	await remove_health()
	assert_between(_player.Health, -9, 0, "Player health within acceptable bounds")

func remove_health():
	var rnjesus = RandomNumberGenerator.new()
	for i in (_player.MaxHealth/4 + 10):
		await wait_seconds(1)
		_player.affectHealth(-rnjesus.randi_range(1, 5))
		print_debug(_player.Health)
		if get_signal_emit_count(_player, "PlayerDeath") > 0:
			return
	return
