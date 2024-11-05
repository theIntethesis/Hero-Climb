extends Node2D
class_name level_controller

var current_level = 1
var enemy_array = PackedVector2Array()
func _ready() -> void:
	var i = 0
	while(i<20):
		add_new_level()
		i += 1
	%EnemyController.spawns = enemy_array
	print(%EnemyController.spawns.size())
	%EnemyController.SpawnEnemies()

func add_new_level():
	var new_level = preload("res://[TL2] Taran/scenes/base_level.tscn").instantiate()
	add_child(new_level)
	new_level.position = Vector2(0,current_level*-192)
	if current_level%5==0:
		new_level.add_shop()
	new_level.build_level()
	current_level += 1

func add_collectable(point : Vector2):
	%CollectableManager.instantiate_collectable(point)

func add_enemy(point : Vector2):
	print(point)
	if randi_range(0,3) == 0:
		enemy_array.append_array(PackedVector2Array([point]))
