extends CharacterBody2D
class_name Zombie

# Variables to control speed and direction
@export var speed = 50
var direction = Vector2.LEFT
var health = 100
var damage = 25
var player
var playerDetected = false

func _physics_process(delta: float) -> void:
	move_and_slide()
	# Move the zombie
	velocity = direction * speed
	
	# Gravity
	if !is_on_floor():
		velocity += Vector2(0, 980) * delta
	
	# Flipping
	$AnimatedSprite2D.flip_h = true if velocity.x < 0 else false
	
	if velocity == Vector2.ZERO:
		$AnimatedSprite2D.stop()


func _ready():
	if owner.get_parent().find_child("Player"):
		player = owner.get_parent().find_child("Player")
	else:
		player = %Player

func _process(delta):
	
	if $"Detect Player".overlaps_body(player):
		$AnimatedSprite2D.play("run")
		var dir = position.x - player.position.x
		direction = Vector2.RIGHT if dir < 0 else Vector2.LEFT
	else:
		direction = Vector2.ZERO

func _on_area_2d_area_entered(area: Area2D) -> void:
	if area.name == "Fireball":
		health -= 50
	if health == 0:
		#Play Death Animation
		#When that's done...
		queue_free()

func _on_area_2d_body_entered(body: Node2D) -> void:
	if body == player:
		#%Player.Health -= damage
		pass
