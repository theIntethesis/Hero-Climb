extends GutTest

var scene = load("res://[TL1] Ferris/tests/testScenes/test_scene1.tscn")

var _level = null
var _player = null
var _sender = InputSender.new(Input)

func before_each():
	_level = add_child_autofree(scene.instantiate())
	_player = _level.get_node("Player")
	await(wait_seconds(.25))

func after_each():
	_sender.release_all()
	_sender.clear()

func test_jump():
	_sender.action_down("jump").hold_for(.25)
	await(_sender.idle)
	assert_lt(_player.velocity, Vector2.ZERO)

func test_free_falling():
	_player.position = Vector2(0, -99999)
	var v = Vector2.ZERO
	for i in 5:
		await(wait_seconds(1))
		var cV = _player.velocity
		print_debug(cV)
		v = cV if cV > v else v
	assert_lte(v, Vector2(0, 980))

func test_attack():
	pass_test("Template Test")
