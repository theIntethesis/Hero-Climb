extends Node2D
class_name level_controller

var enemy_health = 100
var enemy_damage = 25
var current_level = 1
var levels_climbed = 0
var enemy_array = PackedVector2Array()

func _ready() -> void:
	var i = 0
	while(i<5):
		add_new_level()
		i += 1

func add_new_level():
	var new_level = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	new_level.position = Vector2(0,current_level*-192)
	add_child(new_level)
	
	if current_level%5==0:
		new_level.add_shop()
	new_level.build_level()
	current_level += 1
	if current_level % 3 == 0:
		enemy_health += 75
		enemy_damage += 25
	
	%EnemyController.spawns = enemy_array
	# print(%EnemyController.spawns.size())
	%EnemyController.SpawnEnemies(enemy_health, enemy_damage)
	enemy_array.clear()

func add_collectable(point : Vector2):
	%PickupCreator.InstantiateCollectable(point, 'r')

func add_enemy(point : Vector2):
	enemy_array.append_array(PackedVector2Array([point]))

func floor_climbed(_area : Area2D):
	# print("Current floor: "+str(current_level))
	call_deferred("add_new_level")
	PlayerGlobal.GetSetScore(100 * levels_climbed)
	levels_climbed += 1
	%RisingLava.Speed += 1.2
	$FloorMarker.global_position.y -= 192
