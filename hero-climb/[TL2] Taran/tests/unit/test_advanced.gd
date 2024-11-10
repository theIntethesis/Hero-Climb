extends GutTest

var enemies_added = false
var collectables_added = false
var enemies = []
var collectables = []

func test_level_builds():
	var level = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child_autofree(level)
	level.build_level()
	assert_eq(level.get_child_count(), 5)

func add_collectable(point):
	collectables_added = true
	collectables.append(point)

func add_enemy(point):
	enemies_added = true
	enemies.append(point)

func test_enemies_added():
	assert_true(enemies_added)

func test_collectables_added():
	assert_true(collectables_added)

func test_collectable_points():
	for point in collectables:
		assert_typeof(point, TYPE_VECTOR2)

func test_enemy_points():
	for point in enemies:
		assert_typeof(point, TYPE_VECTOR2)

var shop_signal = false
func shop_signal_recieved():
	shop_signal = true

func test_shop_detects_player():
	var shop = preload("res://[TL2] Taran/scenes/shop.tscn").instantiate()
	add_child_autofree(shop)
	var player = preload("res://[TL1] Ferris/scenes/PlayerController.tscn").instantiate()
	add_child_autofree(player)
	player.global_position = shop.global_position + Vector2(0,100)
	
	shop.connect("area_entered", shop_signal_recieved)
	
	await get_tree().create_timer(0.1).timeout
	
	assert_true(shop_signal)
