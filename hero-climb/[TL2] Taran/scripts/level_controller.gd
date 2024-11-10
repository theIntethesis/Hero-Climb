extends Node2D
class_name level_controller

var current_level = 1
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
	
	%EnemyController.spawns = enemy_array
	print(%EnemyController.spawns.size())
	%EnemyController.SpawnEnemies()
	enemy_array.clear()

func add_collectable(point : Vector2):
	%CollectableManager.instantiate_collectable(point, 'r')

func add_enemy(point : Vector2):
	if randi_range(0,2) == 0:
		enemy_array.append_array(PackedVector2Array([point]))

func floor_climbed(area : Area2D):
	print("Current floor: "+str(current_level))
	call_deferred("add_new_level")
	%RisingLava.Speed += 1
	$FloorMarker.global_position.y -= 192
